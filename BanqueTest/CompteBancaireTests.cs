using CompteBanqueNS;
namespace BanqueTest;

[TestClass]
public class CompteBancaireTests
{
    [TestMethod]
    public void VerifierDebitCompteCorrect()
    {
        //Ouvrir un compte
        double soldeInitial = 500000;
        double montantDebit = 400000;
        double soldeAttendu = 100000;
        var compte = new CompteBancaire("Mouhamad KOUNTA", soldeInitial);

        //Débiter
        compte.Debiter(montantDebit);

        //Tester
        double soldeObtenu = compte.Balance;
        Assert.AreEqual(soldeAttendu, soldeObtenu, 0.001, "Compte débité incorrectement");
    }

    [TestMethod]
    [ExpectedExceptionAttribute(typeof(ArgumentOutOfRangeException))]
    public void DebiterMontantSuperieurSoldeLeveArgumentOutOfRange()
    {
        double soldeInitial = 500000;
        double montantDebit = 700000;

        CompteBancaire compte = new CompteBancaire("Mouhamad KOUNTA", soldeInitial);

        compte.Debiter(montantDebit);
    }

    [TestMethod]
    [ExpectedExceptionAttribute(typeof(ArgumentOutOfRangeException))]
    public void DebiterMontantNegatifLeveArgumentOutOfRange()
    {
        double soldeInitial = 500000;
        double montantDebit = -200000;

        CompteBancaire compte = new CompteBancaire("Mouhamad KOUNTA", soldeInitial);

        compte.Debiter(montantDebit);
    }

}
