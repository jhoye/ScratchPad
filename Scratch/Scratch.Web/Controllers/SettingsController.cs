using System.Collections.Generic;
using System.Web.Mvc;
using Scratch.Data.Core;
using Scratch.Web.Models.Settings;

namespace Scratch.Web.Controllers
{
    public class SettingsController : ScratchControllerBase
    {
        public ActionResult Index()
        {
            var model = new IndexViewModel();

            model.Settings.Add(GetDatabaseSettings());

            model.Settings.Add(GetViewModel(Components.Cache));
            
            model.Settings.Add(GetViewModel(Components.Mail));

            return View(model);
        }

        [HttpPost]
        public ActionResult Database(DatabaseSettingsViewModel model)
        {
            Load(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Generic(GenericSettingsViewModel model)
        {
            Components.Settings.Save(model.Settings);

            if (model.Settings.LoadException == null)
            {
                model.SetSignal("Settings were saved.");
            }
            else
            {
                model.SetSignal(model.Settings.LoadException);
            }

            return View(model);
        }
        
        private GenericSettingsViewModel GetViewModel(ISettingsConsumer settingsConsumer)
        {
            var model = new GenericSettingsViewModel()
            {
                Settings = settingsConsumer.Settings,
                Name = settingsConsumer.Settings.Section
            };

            if (settingsConsumer.Settings.IsLoaded)
            {
                model.SetSignal("Settings were loaded from database.");

                settingsConsumer.TestSettings(model);
            }
            else if (settingsConsumer.Settings.LoadException == null)
            {
                model.SetSignal("Settings were not loaded.", Enums.Andons.Red);
            }
            else
            {
                model.SetSignal(settingsConsumer.Settings.LoadException);
            }

            return model;
        }
        
        private DatabaseSettingsViewModel GetDatabaseSettings()
        {
            var model = new DatabaseSettingsViewModel();

            Load(model);

            return model;
        }

        private void Load(IDatabaseSettings model)
        {
            Components.Configuration.Load(model);
            Components.Settings.Load(model);
        }
    }
}