using System.Collections.Generic;
using System.ServiceModel;
using Wostal.WCF.Restaurant.Contract;

namespace Wostal.WCF.Restaurant
{
    [ServiceContract]
    public interface IDishService
    {
        [OperationContract]
        List<DishGroup> GetAllGroupedDishes();

        [OperationContract]
        bool SubmitOrder(Order order);

        [OperationContract]
        List<Order> GetAllOrderHistory();
    }
}