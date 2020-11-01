using Application.Interfaces.Access;
using Application.Interfaces.Repositories;
using Core.Entities;
using Objets100cLib;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class SageClientRepository : ISageClientRepository
    {
        private readonly ISageAccess _sageAccess;
        public SageClientRepository (ISageAccess sageAccess)
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
                IBOClient3 sageClient = null;
                try
                {
                    sageClient = (IBOClient3)_sageAccess.GetSageDatabase.CptaApplication.FactoryClient.Create();
                    IBPTiers tiers = (IBPTiers)_sageAccess.GetSageDatabase.CptaApplication.FactoryTiersType.ReadTypeTiers(TiersType.TiersTypeClient);
                    sageClient.CT_Num = tiers.NextCT_Num;
                    client.CT_Num = sageClient.CT_Num;
                    sageClient.CT_Siret = client.CT_Siret;
                    sageClient.SetDefault();

                    sageClient.CT_Intitule = client.CT_Intitule;
                    sageClient.CT_Qualite = client.CT_Qualite;

                    sageClient.Telecom.EMail = client.Email;
                    sageClient.Telecom.Portable = client.Portable;
                    sageClient.Telecom.Telecopie = client.Telecopie;
                    sageClient.Telecom.Telephone = client.Telephone;

                    sageClient.Adresse.Adresse = client.Adresse;
                    sageClient.Adresse.Complement = client.Complement;
                    sageClient.Adresse.CodePostal = client.CodePostal;
                    sageClient.Adresse.Ville = client.Ville;
                    sageClient.Adresse.Pays = client.Pays;
                    sageClient.CT_Identifiant = client.CT_Identifiant;
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

        public Task<int> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Client>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Client> GetByIdAsync(string CT_Num)
        {
            throw new NotImplementedException();
        }
        public Task<int> UpdateAsync(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
