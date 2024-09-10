using Microsoft.AspNetCore.Authorization;

namespace Identidad.PoliticaPersonalizada
{
    public class PoliticaPermisosUsuario : IAuthorizationRequirement
    {
        public string[] PermitirUsuarios { get; set; }
        public PoliticaPermisosUsuario(params string[] usuario)
        { 
            PermitirUsuarios = usuario;
        }
    }
}
