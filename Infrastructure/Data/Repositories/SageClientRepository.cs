using Application.Interfaces.Access;
using Application.Interfaces.Sage.Repositories;
using Core.Dto;
using Infrastructure.Data.Mapper;
using Objets100cLib;
using System;
using System.Collections.Generic;
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

        private bool OpenDatabase()
        {
            try
            {
                _sageAccess.GetSageDatabase.CompanyServer = _sageAccess.GetDatabaseInstance;
                _sageAccess.GetSageDatabase.CompanyDatabaseName = _sageAccess.GetDatabaseName;
                _sageAccess.GetSageDatabase.Loggable.UserName = _sageAccess.GetUsername;
                _sageAccess.GetSageDatabase.Loggable.UserPwd = _sageAccess.GetUserPwd;
                _sageAccess.GetSageDatabase.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<int> AddAsync(Client client)
        {
            lock (_sageAccess.DatabaseLock)
            {
                if (!OpenDatabase())
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

                    _sageAccess.GetSageDatabase.Close();

                    return int.Parse(sageClient.CT_Num);
                }
                catch (Exception ex) when ((ex.Message.Equals("Cet élément est en cours d'utilisation !")))
                {
                    _sageAccess.GetSageDatabase.Close();
                    return 0;
                }
                catch (Exception e)
                {
                    _sageAccess.GetSageDatabase.Close();
                    return 0;
                }
            }
        }

        public async Task<int> DeleteAsync(string ct_num)
        {
            lock (_sageAccess.DatabaseLock)
            {
                if (!OpenDatabase())
                {
                    return 0;
                }
                if (_sageAccess.GetSageDatabase.CptaApplication.FactoryClient.ExistNumero(ct_num) == false)
                {
                    return 0;
                }
                _sageAccess.GetSageDatabase.CptaApplication.FactoryClient.ReadNumero(ct_num).Remove();
                return 1;
            }
        }

        public async Task<Client> GetByIdAsync(string ct_num)
        {
            lock (_sageAccess.DatabaseLock)
            {
                Client client = new Client();
                if (!OpenDatabase())
                {
                    return client;
                }
                if (_sageAccess.GetSageDatabase.CptaApplication.FactoryClient.ExistNumero(ct_num) == false)
                {
                    _sageAccess.GetSageDatabase.Close();
                    return client;
                }
                IBOClient3 sageClient = _sageAccess.GetSageDatabase.CptaApplication.FactoryClient.ReadNumero(ct_num);
                client = ObjectMapper.IboClientToClient(sageClient);
                _sageAccess.GetSageDatabase.Close();
                return client;
            }
        }

        public Task<int> UpdateAsync(Client client)
        {
            lock (_sageAccess.DatabaseLock)
            {
                if (!OpenDatabase())
                {
                    return Task.FromResult(0);
                }
                if (_sageAccess.GetSageDatabase.CptaApplication.FactoryClient.ExistNumero(client.CT_Num) == false)
                {
                    _sageAccess.GetSageDatabase.Close();
                    return Task.FromResult(0);
                }

                IBOClient3 sageClient = _sageAccess.GetSageDatabase.CptaApplication.FactoryClient.ReadNumero(client.CT_Num);
                sageClient = ObjectMapper.ClientToIboClient(client,sageClient);
                sageClient.Write();

                _sageAccess.GetSageDatabase.Close();
                return Task.FromResult(1);
            }
        }
    }
}