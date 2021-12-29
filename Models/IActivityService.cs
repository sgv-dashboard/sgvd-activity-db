using System.ServiceModel;
namespace Models
{
    [ServiceContract]
    public interface IActivityService
    {
        [OperationContract]
        public Activity getActivityFromId(int id);
    }
}
