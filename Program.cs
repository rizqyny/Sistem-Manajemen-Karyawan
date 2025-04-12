using System;

class Karyawan
{
    private string nama;
    private string id;
    private double gajiPokok;

    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    }

    public string ID
    {
        get { return id; }
        set { id = value; }
    }

    public double GajiPokok
    {
        get { return gajiPokok; }
        set { gajiPokok = value; }
    }

    public Karyawan(string nama, string id, double gajiPokok)
    {
        Nama = nama;
        ID = id;
        GajiPokok = gajiPokok;
    }

    public virtual double HitungGaji()
    {
        return GajiPokok;
    }
}

class KaryawanTetap : Karyawan
{
    private const double BonusTetap = 500000;

    public KaryawanTetap(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok)
    {
    }

    public override double HitungGaji()
    {
        return GajiPokok + BonusTetap;
    }
}

class KaryawanKontrak : Karyawan
{
    private const double PotonganKontrak = 200000;

    public KaryawanKontrak(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok)
    {
    }

    public override double HitungGaji()
    {
        return GajiPokok - PotonganKontrak;
    }
}

class KaryawanMagang : Karyawan
{
    public KaryawanMagang(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok)
    {
    }

    public override double HitungGaji()
    {
        return GajiPokok;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Masukkan jenis karyawan (Tetap/Kontrak/Magang): ");
        string jenis = Console.ReadLine().ToLower();

        Console.Write("Masukkan Nama: ");
        string nama = Console.ReadLine();

        Console.Write("Masukkan ID: ");
        string id = Console.ReadLine();

        Console.Write("Masukkan Gaji Pokok: ");
        double gajiPokok = Convert.ToDouble(Console.ReadLine());

        Karyawan karyawan;

        switch (jenis)
        {
            case "tetap":
                karyawan = new KaryawanTetap(nama, id, gajiPokok);
                break;
            case "kontrak":
                karyawan = new KaryawanKontrak(nama, id, gajiPokok);
                break;
            case "magang":
                karyawan = new KaryawanMagang(nama, id, gajiPokok);
                break;
            default:
                Console.WriteLine("Jenis karyawan tidak valid.");
                return;
        }

        Console.WriteLine("\n--- Informasi Karyawan ---");
        Console.WriteLine($"Nama: {karyawan.Nama}");
        Console.WriteLine($"ID: {karyawan.ID}");
        Console.WriteLine($"Gaji Pokok: {karyawan.GajiPokok}");
        Console.WriteLine($"Gaji Akhir: {karyawan.HitungGaji()}");
    }
}
