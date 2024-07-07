using System;
using System.Collections.Generic;

namespace TareasAPI.Models;

public partial class Peluche
{
    public int IdPeluche { get; set; }
    public string? Nombre { get; set; }
    public double? Precio { get; set; }
    public string? Descripcion { get; set; }
    public string? Imagen { get; set; }
    public int? IdCategoria { get; set; }

    public virtual Categoria? Categoria { get; set; }
}
