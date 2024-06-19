using System;
using System.Collections.Generic;

namespace Proyecto_inventario.DB;

public partial class Usuario
{
    public int Id { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Contrasena { get; set; }

    public int? IrRol { get; set; }

    public int? IdPersona { get; set; }

    public virtual Persona? IdPersonaNavigation { get; set; }

    public virtual Role? IrRolNavigation { get; set; }
}
