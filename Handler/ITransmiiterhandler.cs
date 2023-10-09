using BloodTransferAPI.DTOs;
using BloodTransferAPI.Model;

namespace BloodTransferAPI.Handler
{
    public interface ITransmiiterhandler
    {
        void Add(BloodTransferModel model);
        void Update(TransmitterDTO dto);
        List<TransmitterDTO> Get();
        BloodTransferModel GetById(int id);
        void Delete(BloodTransferModel model);
    }
}
