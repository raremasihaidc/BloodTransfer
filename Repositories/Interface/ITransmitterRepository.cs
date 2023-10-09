using BloodTransferAPI.Model;

namespace BloodTransferAPI.Repositories
{
    public interface ITransmitterRepository
    {
        void Add(BloodTransferModel model);
        void Update(BloodTransferModel model);
        List<BloodTransferModel> Get();
        BloodTransferModel GetById(int id);
        void Delete(BloodTransferModel model);
    }
}
