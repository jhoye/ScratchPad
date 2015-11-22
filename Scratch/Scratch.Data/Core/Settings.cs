﻿using System;
using System.Linq;
using Scratch.Data.Core.DataModel;
using Scratch.Settings;

namespace Scratch.Data.Core
{
    public class Settings : DataBase, ISettings
    {
        public void Load(IDatabaseSettings databaseSettings)
        {
            Action<string, int> addTableInfo = (tableName, recordCount) =>
                databaseSettings.Tables.Add(new DatabaseTableInfoListItem
                {
                    TableName = tableName,
                    RecordCount = recordCount
                });

            Action loadTableInfo = () =>
            {
                addTableInfo("Settings", CoreData.Settings.Count());
                addTableInfo("ContentTypes", CoreData.ContentTypes.Count());
                addTableInfo("Fields", CoreData.Fields.Count());
            };

            databaseSettings.Exists = CoreData.Database.Exists();

            if (databaseSettings.Exists)
            {
                databaseSettings.SetSignal("Database exists.");
                loadTableInfo();
            }
            else
            {
                if (databaseSettings.CreateIfNotExists)
                {
                    if (CoreData.Database.CreateIfNotExists())
                    {
                        databaseSettings.Exists = true;
                        databaseSettings.SetSignal("Database was created.");
                        loadTableInfo();
                    }
                    else
                    {
                        databaseSettings.SetSignal("An attempt to create the database failed.", Enums.Andons.Red);
                    }
                }
                else
                {
                    databaseSettings.SetSignal("Database does not exist.", Enums.Andons.Yellow);
                }
            }
        }
        
        public void Load(GenericSettings genericSettings)
        {
            try
            {
                foreach (var setting in CoreData.Settings.Where(a => a.Section == genericSettings.Section))
                {
                    if (genericSettings.Settings.ContainsKey(setting.Key))
                    {
                        genericSettings.Settings[setting.Key].Value = setting.Value;
                    }
                    else
                    {
                        genericSettings.Settings.Add(
                            setting.Key,
                            new GenericSettingsListItem
                            {
                                Name = setting.Section + " - " + setting.Key,
                                Description = "This is an orphaned setting.",
                                Value = setting.Value
                            });
                    }
                }

                genericSettings.IsLoaded = true;
            }
            catch (Exception exception)
            {
                genericSettings.LoadException = exception;
            }
        }

        public void Save(GenericSettings genericSettings)
        {
            if (String.IsNullOrWhiteSpace(genericSettings.Section))
            {
                genericSettings.LoadException = new ArgumentException("Section is not specified.");
                return;
            }

            try
            {
                foreach (var emptyKey in genericSettings.Settings.Where(a => String.IsNullOrWhiteSpace(a.Key)).Select(a => a.Key))
                {
                    genericSettings.Settings.Remove(emptyKey);
                }

                var settingsInput = genericSettings.Settings.Select(a => new { a.Key, a.Value.Value }).ToList();

                foreach (var setting in CoreData.Settings.Where(a => a.Section == genericSettings.Section).ToList())
                {
                    var settingInput = settingsInput.SingleOrDefault(a => a.Key == setting.Key);

                    if (settingInput == null)
                    {
                        CoreData.Settings.Remove(setting);
                    }
                    else
                    {
                        setting.Value = settingInput.Value;
                        settingsInput.Remove(settingInput);
                    }
                }

                foreach (var settingInput in settingsInput)
                {
                    CoreData.Settings.Add(new Setting
                    {
                        Section = genericSettings.Section,
                        Key = settingInput.Key,
                        Value = settingInput.Value
                    });
                }

                CoreData.SaveChanges();
            }
            catch (Exception exception)
            {
                genericSettings.LoadException = exception;
            }

            Load(genericSettings);
        }
    }
}
