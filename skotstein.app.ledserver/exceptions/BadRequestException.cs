﻿using skotstein.app.ledserver.model;
using skotstein.app.ledserver.tools;
using SKotstein.Net.Http.Context;
using SKotstein.Net.Http.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skotstein.app.ledserver.exceptions
{
    /// <summary>
    /// The exception that is thrown when a request does not meet the expectations of the service. A thrown <see cref="BadRequestException"/> is automatically catched by the underlying
    /// RESTful.NET Framework and converted into an appropriate HTTP Response (i.e. there is no need to catch this exception before sending an HTTP Response). Use the constructor
    /// <see cref="BadRequestException.BadRequestException(string)"/> to specify the error message which is converted into a JSON structure (see <see cref="ErrorMessage"/>) and embedded into the payload
    /// of the HTTP response.
    /// </summary>
    public class BadRequestException : HttpRequestException
    {

        public const string MSG_INVALID_ID = "The 'ID' must be an integer";
        public const string MSG_INVALID_LED_ID = "The 'ID' must have the format [INT]:[INT]";
        public const string MSG_INVALID_PAYLOAD = "The payload is invalid";
        public const string MSG_PAYLOAD_EXPECTED = "A payload is expected";
        public const string MSG_INVALID_LED_COUNT = "'LED count' cannot be negative or greater than 256";
        public const string MSG_INVALID_QUERY_PARAMETER_VALUE = "The value of the query parameter '{QUERY}' is invalid";
        public const string MSG_INVALID_MIN_MAJ_VERSION = "The major or minor version must be an integer";
        public const string MSG_FILE_EXTENSION_NOT_SET = "The file extension cannot be empty";

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/>.
        /// </summary>
        /// <param name="message">the error message</param>
        public BadRequestException(string message)
        {
            this.ErrorMessage = JsonSerializer.SerializeJson(new ErrorMessage(400,message));
            this.ContentType = MimeType.APPLICATION_JSON;
            this.Status = HttpStatus.BadRequest;
        }
    }
}