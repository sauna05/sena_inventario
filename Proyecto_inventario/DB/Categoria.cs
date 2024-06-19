using System;
using System.Collections.Generic;

namespace Proyecto_inventario.DB;

public partial class Categoria
{
    public int Id { get; set; }

    public string? NombreCategoria { get; set; }

    public virtual ICollection<Elemento> Elementos { get; set; } = new List<Elemento>();
}
