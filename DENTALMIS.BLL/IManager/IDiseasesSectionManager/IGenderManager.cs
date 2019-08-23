using System.Collections.Generic;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IDiseasesSectionManager
{
    public interface IGenderManager
    {
        List<Gender>GetAllGender(out int totalrecords, Gender model);



        Gender GetGenderById(int genderId);

        int Save(Gender _gender);

        int Edit(Gender _gender);

        int DeleteGender(int genderId);

        List<Gender> GetAllGenderTitle();
    }
}
