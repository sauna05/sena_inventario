using System;
using System.Collections.Generic;

namespace Proyecto_inventario.DB;

public partial class Persona
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public string? NumeroDocumento { get; set; }

    public virtual ICollection<Elemento> Elementos { get; set; } = new List<Elemento>();

    public virtual ICollection<Prestamo> PrestamoIdFuncionarioAutorizacionNavigations { get; set; } = new List<Prestamo>();

    public virtual ICollection<Prestamo> PrestamoIdPersonaPrestamoNavigations { get; set; } = new List<Prestamo>();

    public virtual ICollection<Prestamo> PrestamoIdPorteroNavigations { get; set; } = new List<Prestamo>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
