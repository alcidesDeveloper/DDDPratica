﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.Models
{
    public class UserModel
    {
        private Guid _id;
                    
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime? _createAt;
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = value == null ? DateTime.UtcNow : value; }
        }

        private DateTime? _updateAt;

        public DateTime? UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = value == null ? DateTime.UtcNow : value; }
        }


        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

    }
}
