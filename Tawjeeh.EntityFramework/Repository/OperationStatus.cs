using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tawjeeh.EntityFramework.Repository
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("Status: {Status}")]
    public class OperationStatus
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="OperationStatus"/> is status.
        /// </summary>
        /// <value>
        ///   <c>true</c> if status; otherwise, <c>false</c>.
        /// </value>
        public bool Status { get; set; }
        /// <summary>
        /// Gets or sets the records affected.
        /// </summary>
        /// <value>
        /// The records affected.
        /// </value>
        public int RecordsAffected { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the operation identifier.
        /// </summary>
        /// <value>
        /// The operation identifier.
        /// </value>
        public Object OperationID { get; set; }
        /// <summary>
        /// Gets or sets the exception message.
        /// </summary>
        /// <value>
        /// The exception message.
        /// </value>
        public string ExceptionMessage { get; set; }
        /// <summary>
        /// Gets or sets the exception stack trace.
        /// </summary>
        /// <value>
        /// The exception stack trace.
        /// </value>
        public string ExceptionStackTrace { get; set; }
        /// <summary>
        /// Gets or sets the exception inner message.
        /// </summary>
        /// <value>
        /// The exception inner message.
        /// </value>
        public string ExceptionInnerMessage { get; set; }
        /// <summary>
        /// Gets or sets the exception inner stack trace.
        /// </summary>
        /// <value>
        /// The exception inner stack trace.
        /// </value>
        public string ExceptionInnerStackTrace { get; set; }
        /// <summary>
        /// Creates from exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        public static OperationStatus CreateFromException(string message, Exception ex)
        {
            OperationStatus opStatus = new OperationStatus
            {
                Status = false,
                Message = message,
                OperationID = null
            };

            if (ex != null)
            {
                opStatus.ExceptionMessage = ex.Message;
                opStatus.ExceptionStackTrace = ex.StackTrace;
                opStatus.ExceptionInnerMessage = (ex.InnerException == null) ? null : ex.InnerException.Message;
                opStatus.ExceptionInnerStackTrace = (ex.InnerException == null) ? null : ex.InnerException.StackTrace;
            }
            return opStatus;
        }
    }
}
