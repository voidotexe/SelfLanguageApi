﻿/*
 * By: voidotexe
 * https://www.github.com/voidotexe
*/

using System;

namespace AccountMicroService.Data
{
    public partial class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
