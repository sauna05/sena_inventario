using System;
using System.Collections.Generic;

namespace Proyecto_inventario.DB;

public partial class Prestamo
{
    public int Id { get; set; }

    public int? IdPersonaPrestamo { get; set; }

    public byte[]? FechaHoraPrestamo { get; set; }

    public DateOnly? FechaLimite { get; set; }

    public int? IdElemento { get; set; }

    public int? IdEstadoPrestamo { get; set; }

    public int? IdFuncionarioAutorizacion { get; set; }

    public int? IdPortero { get; set; }

    public virtual ICollection<EstadoElementosPrestamo> EstadoElementosPrestamos { get; set; } = new List<EstadoElementosPrestamo>();

    public virtual Elemento? IdElementoNavigation { get; set; }

    public virtual EstadoPrestamo? IdEstadoPrestamoNavigation { get; set; }

    public virtual Persona? IdFuncionarioAutorizacionNavigation { get; set; }

    public virtual Persona? IdPersonaPrestamoNavigation { get; set; }

    public virtual Persona? IdPorteroNavigation { get; set; }
}
