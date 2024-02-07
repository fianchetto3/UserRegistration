using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegApp.Entities;
using UserRegApp.Repositories;

namespace UserRegApp.Services
{
    internal class AddressService
    {
        private readonly AddressRepository _addressRepository;

        public AddressService(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public AddressEntity CreateAddress(string Street, string postalCode, string City )
        {
            try
            {
                var addressEntity = _addressRepository.Read(x => x.Street == Street && x.PostalCode == postalCode && x.City == City);

                if (addressEntity == null)
                {
                    addressEntity = new AddressEntity() { Street = Street, PostalCode = postalCode, City = City };
                    addressEntity = _addressRepository.Create(addressEntity);
                }



                return addressEntity;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }



          
  
        }


        public AddressEntity GetAddressByStreet(string Street)
        {
            var addressEntity = _addressRepository.Read(x => x.Street == Street);
            return addressEntity;
        }

        public AddressEntity GetAddressbyId(int id)
        {
            var addressEntity = _addressRepository.Read(x => x.Id == id);
            return addressEntity;
        }
        public AddressEntity GetAddressByPostalCode(string postalCode)
        {
            var addressEntity = _addressRepository.Read(x => x.PostalCode == postalCode);
            return addressEntity;
        }
        public AddressEntity GetAddressByCity(string City)
        {
            var addressEntity = _addressRepository.Read(x => x.City == City);
            return addressEntity;
        }


        public IEnumerable<AddressEntity> GetAllAddresses()
        {
            var addresses = new List<AddressEntity>();
            return addresses;
        }

        public AddressEntity UpdateRole(AddressEntity addressEntity)
        {
            var updateAddressEntity = _addressRepository.Update(x => x.Id == addressEntity.Id, addressEntity);
            return updateAddressEntity;
        }

        public void DeleteAddress(int id)
        {
            _addressRepository.Delete(x => x.Id == id);
        }


    }
}
