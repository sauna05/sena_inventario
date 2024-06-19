using System;
using System.Collections.Generic;

namespace Proyecto_inventario.DB;

public partial class Elemento
{
    public int Id { get; set; }

    public string? NombreElemento { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdPersonaEncargada { get; set; }

    public int? IdEstado { get; set; }

    public int? Cantidad { get; set; }

    public string? CodigoElemento { get; set; }

    public virtual ICollection<FotoElemento> FotoElementos { get; set; } = new List<FotoElemento>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual EstadoElemento? IdEstadoNavigation { get; set; }

    public virtual Persona? IdPersonaEncargadaNavigation { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
}
