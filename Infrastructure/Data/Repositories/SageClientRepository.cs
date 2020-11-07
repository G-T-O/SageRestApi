using Application.Interfaces.Access;
using Application.Interfaces.Sage.Repositories;
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

        public async Task<int> AddAsync(Client client)
        {
            lock (_sageAccess.DatabaseLock)
            {
                if (!Utility.ComObject.Open(_sageAccess))
                {
                    return 1;
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

                    return int.Parse(sageClient.CT_Num);
                }
                catch (Exception ex) when ((ex.Message.Equals("Cet élément est en cours d'utilisation !")))
                {
                    Utility.ComObject.Close(_sageAccess);
                    return 0;
                }
                catch (Exception e)
                {
                    Utility.ComObject.Close(_sageAccess);
                    return 0;
                }
            }
        }

        public async Task<int> DeleteAsync(string ct_num)
        {
            lock (_sageAccess.DatabaseLock)
            {
                if (!Utility.ComObject.Open(_sageAccess))
                {
                    return 0;
                }
                if (_sageAccess.GetSageDatabase.CptaApplication.FactoryClient.ExistNumero(ct_num) == false)
                {
                    Utility.ComObject.Close(_sageAccess);
                    return 0;
                }
                _sageAccess.GetSageDatabase.CptaApplication.FactoryClient.ReadNumero(ct_num).Remove();
                Utility.ComObject.Close(_sageAccess);
                return 1;
            }
        }

        public async Task<Client> GetByIdAsync(string ct_num)
        {
            lock (_sageAccess.DatabaseLock)
            {
                Client client = new Client();
                if (!Utility.ComObject.Open(_sageAccess))
                {
                    return client;
                }
                if (_sageAccess.GetSageDatabase.CptaApplication.FactoryClient.ExistNumero(ct_num) == false)
                {
                    Utility.ComObject.Close(_sageAccess);
                    return client;
                }
                IBOClient3 sageClient = _sageAccess.GetSageDatabase.CptaApplication.FactoryClient.ReadNumero(ct_num);
                client = ObjectMapper.IboClientToClient(sageClient);
                Utility.ComObject.Close(_sageAccess);
                return client;
            }
        }

        public Task<int> UpdateAsync(Client client)
        {
            lock (_sageAccess.DatabaseLock)
            {
                if (!Utility.ComObject.Open(_sageAccess))
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