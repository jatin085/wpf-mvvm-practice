﻿using System;
using System.ComponentModel.DataAnnotations;
using Zza.Data;

namespace ZzaDesktop
{
    public sealed class SimpleEditableCustomer : ValidatableBindableBase
    {
        private Guid id;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;

        public SimpleEditableCustomer(Customer customer, bool editMode)
        {
            this.Id = customer.Id;

            if (editMode)
            {
                this.FirstName = customer.FirstName;
                this.LastName = customer.LastName;
                this.Email = customer.Email;
                this.Phone = customer.Phone;
            }
        }

        public Guid Id
        {
            get => this.id;
            set => this.SetProperty(ref this.id, value);
        }

        [Required]
        public string FirstName
        {
            get => this.firstName;
            set => this.SetProperty(ref this.firstName, value);
        }

        [Required]
        public string LastName
        {
            get => this.lastName;
            set => this.SetProperty(ref this.lastName, value);
        }

        [EmailAddress]
        public string Email
        {
            get => this.email;
            set => this.SetProperty(ref this.email, value);
        }

        [Phone]
        public string Phone
        {
            get => this.phone;
            set => this.SetProperty(ref this.phone, value);
        }

        internal void Update(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            if (customer.Id != this.Id)
            {
                throw new InvalidOperationException("Customer IDs do not match");
            }

            customer.FirstName = this.FirstName;
            customer.LastName = this.LastName;
            customer.Email = this.Email;
            customer.Phone = this.Phone;
        }
    }
}
