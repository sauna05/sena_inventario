using System;
using System.Collections.Generic;

namespace Proyecto_inventario.DB;

public partial class EstadoElementosPrestamo
{
    public int Id { get; set; }

    public int? IdEstadoElemento { get; set; }

    public int? IdPrestamo { get; set; }

    public virtual EstadoElemento? IdEstadoElementoNavigation { get; set; }

    public virtual Prestamo? IdPrestamoNavigation { get; set; }
}
