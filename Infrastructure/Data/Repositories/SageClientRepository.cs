using Infrastructure.Data.IDBAccess;
using Infrastructure.IRepositories.Sage;
using Core.Dto;
using Infrastructure.Data.Mapper;
using Objets100cLib;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class SageClientRepository : ISageClientRepository
    {
        private readonly ISageAccess _sageDataAccess;
        public SageClientRepository(ISageAccess sageDataAccess)
        {
            _sageDataAccess = sageDataAccess;
        }

        public Task<string> Create(Client client)
        {
            lock (_sageDataAccess.DatabaseLock)
            {
                if (Utility.ComObject.Open(_sageDataAccess) == false)
                {
                    throw new Exception("Error while opening the com database");
                }

                try
                {
                    IBOClient3 sageClient = (IBOClient3)_sageDataAccess.GetSageDatabase.CptaApplication.FactoryClient.Create();
                    sageClient.CT_Num = _sageDataAccess.GetSageDatabase.CptaApplication.FactoryTiersType.ReadTypeTiers(TiersType.TiersTypeClient).NextCT_Num;
                    sageClient.CategorieCompta = _sageDataAccess.GetSageDatabase.FactoryCategorieComptaVente.ReadIntitule("France"); // TO DO add other country and new VAT ID EU / EXO / FR / DOM 7,5.5,20,0 %
                    sageClient.CompteGPrinc = (IBOCompteG3)_sageDataAccess.GetSageDatabase.CptaApplication.FactoryCompteG.ReadNumero("411000");
                    sageClient = ObjectMapper.CreateClientToIboClient(client, sageClient);
                    Utility.ComObject.Close(_sageDataAccess);
                    return Task.FromResult(sageClient.CT_Num);
                }
                catch (Exception ex) when ((ex.Message.Equals("Cet élément est en cours d'utilisation !")))
                {
                    Utility.ComObject.Close(_sageDataAccess);
                    throw new Exception("Element in use");
                }
                catch (Exception e)
                {
                    Utility.ComObject.Close(_sageDataAccess);
                    throw new Exception($"Error while creating user {e}");
                }
            }
        }

        public Task<int> Delete(string ct_num)
        {
            lock (_sageDataAccess.DatabaseLock)
            {
                if (Utility.ComObject.Open(_sageDataAccess) == false)
                {
                    throw new Exception("Error while opening the com database");
                }
                if (_sageDataAccess.GetSageDatabase.CptaApplication.FactoryClient.ExistNumero(ct_num) == false)
                {
                    Utility.ComObject.Close(_sageDataAccess);
                    throw new Exception("Error client not found");
                }
                try
                {
                    IBOClient3 client = _sageDataAccess.GetSageDatabase.CptaApplication.FactoryClient.ReadNumero(ct_num);
                    client.Remove();
                    Utility.ComObject.Close(_sageDataAccess);
                    return Task.FromResult(1);
                }catch(Exception e)
                {
                    Utility.ComObject.Close(_sageDataAccess);
                    throw;
                }
            }
        }

        public Task<int> Update(Client client)
        {
            lock (_sageDataAccess.DatabaseLock)
            {
                if (Utility.ComObject.Open(_sageDataAccess) == false)
                {
                    throw new Exception("Error while opening the com database");
                }
                if (_sageDataAccess.GetSageDatabase.CptaApplication.FactoryClient.ExistNumero(client.SageCode) == false)
                {
                    Utility.ComObject.Close(_sageDataAccess);
                    throw new Exception("Error client not found");
                }

                try
                {
                    IBOClient3 sageClient = _sageDataAccess.GetSageDatabase.CptaApplication.FactoryClient.ReadNumero(client.SageCode);
                    sageClient = ObjectMapper.UpdateClientToIboClient(client,sageClient);
                    Utility.ComObject.Close(_sageDataAccess);
                    return Task.FromResult(1);

                }catch(Exception e)
                {
                    Utility.ComObject.Close(_sageDataAccess);
                    throw;
                }
            }
        }
    }
}