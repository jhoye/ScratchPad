<?php

$method = $_SERVER['REQUEST_METHOD'];

switch ($method)
{
    case 'GET':
        $code = $_GET['code'] == '' ? 200 : intval($_GET['code']);
        break;
        
    case 'POST':
        $code = $_POST['code'] == '' ? 200 : intval($_POST['code']);
        break;
    
    case 'PUT':
        $code = 200;
        break;
    
    case 'DELETE':
        $code = 200;
        break;
    
    default:
        $code = 405;
        break;
}

switch ($code)
{
    case 100:
        $reason = 'Continue';
        // Client should continue sending its request. This is a special status code; see below for details.
        break;

    case 101:
        $reason = 'Switching Protocols';
        // The client has used the Upgrade header to request the use of an alternative protocol and the server has agreed.
        break;

    case 200:
        $reason = 'OK';
        // Generic successful request message response. This is the code sent most often when a request is filled normally.
        break;

    case 201:
        $reason = 'Created';
        // The request was successful and resulted in a resource being created. This would be a typical response to a PUT method.
        break;

    case 202:
        $reason = 'Accepted';
        // The request was accepted by the server but has not yet been processed. This is an intentionally Ònon-commitalÓ response that does not tell the client whether or not the request will be carried out; the client determines the eventual disposition of the request in some unspecified way. It is used only in special circumstances.
        break;

    case 203:
        $reason = 'Non-Authoritative Information';
        // The request was successful, but some of the information returned by the server came not from the original server associated with the resource but from a third party.
        break;

    case 204:
        $reason = 'No Content';
        // The request was successful, but the server has determined that it does not need to return to the client an entity body.
        break;

    case 205:
        $reason = 'Reset Content';
        // The request was successful; the server is telling the client that it should reset the document from which the request was generated so that a duplicate request is not sent. This code is intended for use with forms.
        break;

    case 206:
        $reason = 'Partial Content';
        // The server has successfully fulfilled a partial GET request. See the topic on methods for more details on this, as well as the description of the Range header.
        break;

    case 300:
        $reason = 'Multiple Choices';
        // The resource is represented in more than one way on the server. The server is returning information describing these representations, so the client can pick the most appropriate one, a process called agent-driven negotiation.
        break;

    case 301:
        $reason = 'Moved Permanently';
        // The resource requested has been moved to a new URL permanently. Any future requests for this resource should use the new URL.
        // This is the proper method of handling situations where a file on a server is renamed or moved to a new directory. Most people don't bother setting this up, which is why URLs ÒbreakÓ so often, resulting in 404 errors as discussed below.
        break;

    case 302:
        $reason = 'Found';
        // The resource requested is temporarily using a different URL. The client should continue to use the original URL. See code 307.
        break;

    case 303:
        $reason = 'See Other';
        // The response for the request can be found at a different URL, which the server specifies. The client must do a fresh GET on that URL to see the results of the prior request.
        break;

    case 304:
        $reason = 'Not Modified';
        // The client sent a conditional GET request, but the resource has not been modified since the specified date/time, so the server has not sent it.
        break;

    case 305:
        $reason = 'Use Proxy';
        // To access the requested resource, the client must use a proxy, whose URL is given by the server in its response.
        break;

    case 307:
        $reason = 'Temporary Redirect';
        // The resource is temporarily located at a different URL than the one the client specified.
        // Note that 302 and 307 are basically the same status code. 307 was created to clear up some confusion related to 302 that occurred in earlier versions of HTTP (which I'd rather not get into!)
        break;

    case 400:
        $reason = 'Bad Request';
        // Server says, Òhuh?Ó J Generic response when the request cannot be understood or carried out due to a problem on the client's end.
        break;

    case 401:
        $reason = 'Unauthorized';
        // The client is not authorized to access the resource. Often returned if an attempt is made to access a resource protected by a password or some other means without the appropriate credentials.
        break;

    case 403:
        $reason = 'Forbidden';
        // The request has been disallowed by the server. This is a generic Òno wayÓ response that is not related to authorization. For example, if the maintainer of Web site blocks access to it from a particular client, any requests from that client will result in a 403 reply.
        break;

    case 404:
        $reason = 'Not Found';
        // The most common HTTP error message, returned when the server cannot locate the requested resource. Usually occurs due to either the server having moved/removed the resource, or the client giving an invalid URL (misspellings being the most common cause.)
        break;

    case 405:
        $reason = 'Method Not Allowed';
        // The requested method is not allowed for the specified resource. The response includes an Allow header that indicates what methods the server will permit.
        break;

    case 406:
        $reason = 'Not Acceptable';
        // The client sent a request that specifies limitations that the server cannot meet for the specified resource. This error may occur if an overly-restrictive list of conditions is placed into a request such that the server cannot return any part of the resource.
        break;

    case 407:
        $reason = 'Proxy Authentication Required';
        // Similar to 401, but the client must first authenticate itself with the proxy.
        break;

    case 408:
        $reason = 'Request Timeout';
        // The server was expecting the client to send a request within a particular time frame and the client didn't send it.
        break;

    case 409:
        $reason = 'Conflict';
        // The request could not be filled because of a conflict of some sort related to the resource. This most often occurs in response to a PUT method, such as if one user tries to PUT a resource that another user has open for editing, for example.
        break;

    case 410:
        $reason = 'Gone';
        // The resource is no longer available at the server, which does not know its new URL. This is a more specific version of the 404 code that is used only if the server knows that the resource was intentionally removed. It is seen rarely (if ever) compared to 404.
        break;

    case 411:
        $reason = 'Length Required';
        // The request requires a Content-Length header field and one was not included.
        break;

    case 412:
        $reason = 'Precondition Failed';
        // Indicates that the client specified a precondition in its request, such as the use of an If-Match header, which evaluated to a false value. This indicates that the condition was not satisfied so the request is not being filled. This is used by clients in special cases to ensure that they do not accidentally receive the wrong resource.
        break;

    case 413:
        $reason = 'Request Entity Too Large';
        // The server has refused to fulfill the request because the entity that the client is requesting is too large.
        break;

    case 414:
        $reason = 'Request-URI Too Long';
        // The server has refused to fulfill the request because the URL specified is longer than the server can process. This rarely occurs with properly-formed URLs but may be seen if clients try to send gibberish to the server.
        break;

    case 415:
        $reason = 'Unsupported Media Type';
        // The request cannot be processed because it contains an entity using a media type the server does not support.
        break;

    case 416:
        $reason = 'Requested Range Not Satisfiable';
        // The client included a Range header specifying a range of values that is not valid for the resource. An example might be requesting bytes 3,000 through 4,000 of a 2,400-byte file.
        break;

    case 417:
        $reason = 'Expectation Failed';
        // The request included an Expect header that could not be satisfied by the server.
        break;

    case 500:
        $reason = 'Internal Server Error';
        // Generic error message indicating that the request could not be fulfilled due to a server problem.
        break;

    case 501:
        $reason = 'Not Implemented';
        // The server does not know how to carry out the request, so it cannot satisfy it.
        break;

    case 502:
        $reason = 'Bad Gateway';
        // The server, while acting as a gateway or proxy, received an invalid response from another server it tried to access on the client's behalf.
        break;

    case 503:
        $reason = 'Service Unavailable';
        // The server is temporarily unable to fulfill the request for internal reasons. This is often returned when a server is overloaded or down for maintenance.
        break;

    case 504:
        $reason = 'Gateway Timeout';
        // The server, while acting as a gateway or proxy, timed out while waiting for a response from another server it tried to access on the client's behalf.
        break;

    case 505:
        $reason = 'HTTP Version Not Supported';
        // The request used a version of HTTP that the server does not understand.
        break;
    
    default:
        $code = 200;
        $reason = 'OK';
        break;
}

header('HTTP/1.1 ' + $code + ' ' + $reason, true, $code);

header('Content-Type: application/json');

?>
{
    "method" : "<?= $method ?>",
    "code" : <?= $code ?>,
    "reason" : "<?= $reason ?>"
}