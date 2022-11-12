using System;

namespace CompteBanqueNS;
public class CompteBancaire
{
    private string m_nomClient;
    private double m_solde;
    private bool m_bloque = false;
    private CompteBancaire() { }
    public CompteBancaire(string nomClient, double solde)
    {
        m_nomClient = nomClient;
        m_solde = solde;
    }
    public string nomClient
    {
        get { return m_nomClient; }
    }
    public double Balance
    {
        get { return m_solde; }
    }
    public void Debiter(double montant)
    {
        if (m_bloque)
        {
            throw new Exception("Compte bloqué");
        }
        if (montant > m_solde)
        {
            throw new ArgumentOutOfRangeException("Montant débité doit être supérieur ou égal au solde disponible");
        }
        if (montant < 0)
        {
            throw new ArgumentOutOfRangeException("Montant doit être positif");
        }
        m_solde -= montant;
    }
    public void Crediter(double montant)
    {
        if (m_bloque)
        {
            throw new Exception("Compte bloqué");
        }
        if (montant < 0)
        {
            throw new ArgumentOutOfRangeException("Montant crédité doit être superieur à zéro");
        }
        m_solde += montant;
    }
    private void BloquerCompte()
    {
        m_bloque = true;
    }
    private void DebloquerCompte()
    {
        m_bloque = false;
    }
    public static void Main()
    {
        CompteBancaire cb = new CompteBancaire("Mouhamad KOUNTA", 500000);

        cb.Crediter(500000);
        cb.Debiter(400000);
        Console.WriteLine("Solde disponible à F{0}", cb.Balance);
    }
}

