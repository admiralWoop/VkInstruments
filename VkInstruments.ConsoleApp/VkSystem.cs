using System;
using VkNet.Exception;
using VkNet.Model;

namespace VkInstruments.ConsoleApp
{
    internal class VkSystem : Core.VkSystem.VkSystem
    {
        private string _login;
        private string _password;

        private void SetCredentials()
        {
            Console.Write("Введите свой номер телефона или email: ");
            _login = Console.ReadLine();
            Console.Write("\nВведите свой пароль: ");
            _password = Console.ReadLine();
        }

        public override void Auth()
        {
            SetCredentials();
            bool isLoggedIn;
            try
            {
                Vk.Authorize(new ApiAuthParams
                {
                    ApplicationId = 6634517,
                    Login = _login,
                    Password = _password,
                    Settings = SettingFilters
                });
                isLoggedIn = Vk.IsAuthorized;
            }
            catch (VkApiAuthorizationException)
            {
                isLoggedIn = false;
                Console.WriteLine("Authorization failed: Incorrect credentials");
                SetCredentials();
            }
            catch (VkApiException ex)
            {
                isLoggedIn = false;
                Console.WriteLine(ex.Message + "\n");
                SetCredentials();
            }
            if (isLoggedIn)
            {
                Console.Clear();
                Console.Write("Вход выполнен успешно!");
            }
        }
    }
}
