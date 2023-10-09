using BloodTransferAPI.DTOs;
using BloodTransferAPI.Model;

namespace BloodTransferAPI.Handler
{
    public interface ITransferHandler
    {
        void Update(TransferDTO dto);
        List<BloodTransferModel> Get();
        BloodTransferModel GetById(int id);
    }
}
