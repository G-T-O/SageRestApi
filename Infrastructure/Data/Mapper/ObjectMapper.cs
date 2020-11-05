using Core.Dto;
using Application.Interfaces.Access;
using Objets100cLib;

namespace Infrastructure.Data.Mapper
{
    public static class ObjectMapper
    {
        public static IBOClient3 ClientToIboClient(Client client,ISageAccess sageAccess)
        {
           IBOClient3 sageClient = (IBOClient3) sageAccess.GetSageDatabase.CptaApplication.FactoryClient.Create();
            sageClient.CT_Qualite = "SARL";
           return sageClient;
        }
/*        public static Client IBOClientToClient(IBOClient3 client)
        {

        }*/
    }
}
