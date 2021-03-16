using System;

namespace StoredProcedureEFCore.UTest
{
  // introduces nullable properties, to map some bad assumptions
  // about nullable data between the C# model and the database
  internal class DbModel : ICloneable
  {
    public sbyte? Sb { get; set; }
    public char? C { get; set; }
    public short? S { get; set; }
    public int? I { get; set; }
    public long? L { get; set; }

    public byte? B { get; set; }
    public ushort? Us { get; set; }
    public uint? Ui { get; set; }
    public ulong? Ul { get; set; }

    public float? F { get; set; }
    public double? D { get; set; }

    public bool? Bo { get; set; }

    public string Str { get; set; }

    public DateTime? Date { get; set; }
    public Decimal? Dec { get; set; }
    public YN? En { get; set; }

    public object Clone()
    {
      return MemberwiseClone();
    }
  }
}
