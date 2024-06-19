﻿using System;
using System.Collections.Generic;

namespace Proyecto_inventario.DB;

public partial class Role
{
    public int Id { get; set; }

    public string NombreRol { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
