using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Core.System
{
    public enum LoginResults
    {
        /// <summary>
        /// Login successful
        /// </summary>
        Successful = 1,
        /// <summary>
        ///  User dies not exist (phone or username)
        /// </summary>
        UserNotExist = 2,
        /// <summary>
        /// Wrong password
        /// </summary>
        WrongPassword = 3,
        /// <summary>
        /// Account have not been activated
        /// </summary>
        NotEnable = 4,
        /// <summary>
        /// User has been deleted 
        /// </summary>
        Deleted = 5,


        /// <summary>
        ///  Business dies not exist
        /// </summary>
        BusinessNotExist=6,
  
    }
}
