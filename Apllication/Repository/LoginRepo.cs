using Api.Apllication.Interfaces;
using Api.Apllication.Interfaces.Domain;
using Api.Apllication.Service;
using Api.Domain;
using Api.Domain.Request;
using Api.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Repository
{
    public class LoginRepo : ILoginRepo
    {
        private readonly IUsuarioRepo userRepo;

        public LoginRepo(
            IUsuarioRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        public async Task<bool> UpdatePassword(string email, string password)
        {
            return await userRepo.UpdatePassword(email, password);
        }

        public async Task<LoginRes> Login(string login, string password)
        {
            Usuario user = await userRepo.GetUsuarioByLogin(login, password);

            if (user != null)
            {
                if (user.Senha == password)
                {
                    string token = TokenService.GenerateToken(user);

                    return await userRepo.UpdateToken(user, token);
                }                    
                else
                    throw new Exception("Senha incorreta!");
            }
            else
                throw new Exception("Usuario não encontrado!");            
        }

        public async Task<LoginRes> CriarUsuario(UsuarioReq usi)
        {
            if(await userRepo.GetUsuarioByEmailAndDoc(usi.Email, usi.Documento) == null)
            {
                await userRepo.PostUsuario(usi);

                return await Login(usi.Email, usi.Senha);

            }
            else
            {
                throw new Exception("Email ou CPF/CNPJ já cadastratos");

            }

            
        }

        public bool ValidateToken(string token)
        {
            return TokenService.ValidateToken(token);
        }
    }
}
