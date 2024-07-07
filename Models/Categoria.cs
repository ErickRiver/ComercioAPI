using System;
using System.Collections.Generic;

namespace TareasAPI.Models;

public partial class Categoria
{
    public Categoria()
    {
        Peluches = new HashSet<Peluche>();
    }

    public int IdCategoria { get; set; }
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Peluche> Peluches { get; set; }
}
