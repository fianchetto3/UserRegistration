using System;
using System.Collections.Generic;
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
        public AddressEntity CreateAddress(string street, string postalCode, string city )
        {
            var addressEntity = _addressRepository.Read(x => x.Street == street && x.PostalCode == postalCode && x.City == city);
            addressEntity ??= _addressRepository.Create(new AddressEntity() { Street = street, PostalCode = postalCode, City = city });
            return addressEntity;
        }


        public AddressEntity GetAddressByStreet(string street)
        {
            var addressEntity = _addressRepository.Read(x => x.Street == street);
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
        public AddressEntity GetAddressByCity(string city)
        {
            var addressEntity = _addressRepository.Read(x => x.City == city);
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
