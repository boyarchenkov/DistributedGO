using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace DGO
{
    [ServiceContract(Namespace = "http://DGO")]
    public interface ITaskManager
    {
        [OperationContract]
        int RegisterComputer(string description);
        [OperationContract]
        TaskInfo[] Next(int id, TaskInfo[] finished, out int error_code);
    }
}
