using BloodTransferAPI.Model;

namespace BloodTransferAPI.Repositories
{
    public interface ITransferRepository
    {
        void Update(BloodTransferModel model);
        List<BloodTransferModel> Get();
        BloodTransferModel GetById(int id);
    }
}
