/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFLibrary;
using VFViewModel.Commands;

namespace VFViewModel
{
    public class LoginVM
    {
        private User user;

        public User User
        {
            get => user;
            set { user = value; }
        }
        public RegisterCommand RegisterCommand { get; set; }
        public LoginCommands LoginCommands { get; set; }
        public LoginVM()
        {
            RegisterCommand = new RegisterCommand(this);
            LoginCommands = new LoginCommands(this);
        }

    }
}
*/