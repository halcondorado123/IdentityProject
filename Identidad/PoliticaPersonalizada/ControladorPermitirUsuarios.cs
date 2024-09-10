using Microsoft.AspNetCore.Authorization;

namespace Identidad.PoliticaPersonalizada
{
    public class ControladorPermitirUsuarios : AuthorizationHandler<PoliticaPermisosUsuario>
    {
        // Se sobreescribe el metodo para validar que este dentro del listado de usuarios permitidos
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PoliticaPermisosUsuario requirement)
        {
            // User.Identity.Name = Para obtener el nombre del usuario que inicio sesion
            if (requirement.PermitirUsuarios.Any(usuario => usuario.Equals(context.User.Identity.Name, StringComparison.OrdinalIgnoreCase)))
            {
                context.Succeed(requirement);
            }
            else 
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
