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
        private readonly ISageAccess _sageAccess;
        public SageClientRepository(ISageAccess sageAccess)
        {
            _sageAccess = sageAccess;
        }

        public Task<string> Create(Client client)
        {
            lock (_sageAccess.DatabaseLock)
            {
                if (Utility.ComObject.Open(_sageAccess) == false)
                {
                    return null;
                }

                try
                {
                    IBOClient3 sageClient = (IBOClient3)_sageAccess.GetSageDatabase.CptaApplication.FactoryClient.Create();
                    sageClient.CT_Num = _sageAccess.GetSageDatabase.CptaApplication.FactoryTiersType.ReadTypeTiers(TiersType.TiersTypeClient).NextCT_Num;

                    sageClient = ObjectMapper.ClientToNewIboClient(client, sageClient);
                    sageClient.SetDefault();
                    sageClient.WriteDefault();
                    sageClient.Read();

                    Utility.ComObject.Close(_sageAccess);

                    return Task.FromResult(sageClient.CT_Num);
                }
                catch (Exception ex) when ((ex.Message.Equals("Cet élément est en cours d'utilisation !")))
                {
                    Utility.ComObject.Close(_sageAccess);
                    return null;
                }
                catch (Exception e)
                {
                    Utility.ComObject.Close(_sageAccess);
                    return null;
                }
            }
        }

        public Task<int> Delete(string ct_num)
        {
            lock (_sageAccess.DatabaseLock)
            {
                if (Utility.ComObject.Open(_sageAccess) == false)
                {
                    return Task.FromResult(0);
                }
                if (_sageAccess.GetSageDatabase.CptaApplication.FactoryClient.ExistNumero(ct_num) == false)
                {
                    Utility.ComObject.Close(_sageAccess);
                    return Task.FromResult(0);
                }
                _sageAccess.GetSageDatabase.CptaApplication.FactoryClient.ReadNumero(ct_num).Remove();
                Utility.ComObject.Close(_sageAccess);
                return Task.FromResult(1);
            }
        }

        public Task<int> Update(Client client)
        {
            lock (_sageAccess.DatabaseLock)
            {
                if (Utility.ComObject.Open(_sageAccess) == false)
                {
                    return Task.FromResult(0);
                }
                if (_sageAccess.GetSageDatabase.CptaApplication.FactoryClient.ExistNumero(client.CT_Num) == false)
                {
                    Utility.ComObject.Close(_sageAccess);
                    return Task.FromResult(0);
                }

                IBOClient3 sageClient = _sageAccess.GetSageDatabase.CptaApplication.FactoryClient.ReadNumero(client.CT_Num);
                sageClient = ObjectMapper.ClientToIboClient(client,sageClient);
                sageClient.Write();

                Utility.ComObject.Close(_sageAccess);
                return Task.FromResult(1);
            }
        }
    }
}