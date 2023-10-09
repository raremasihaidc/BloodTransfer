using BloodTransferAPI.DTOs;
using BloodTransferAPI.Model;

namespace BloodTransferAPI.Handler
{
    public interface IRecieverHandler
    {
        void Add(BloodTransferModel model);
        void Update(RecieverDTO dto);
        List<RecieverDTO> Get();
        BloodTransferModel GetById(int id);
        void Delete(BloodTransferModel model);

    }
}
