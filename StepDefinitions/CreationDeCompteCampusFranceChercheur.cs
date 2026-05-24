using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Reqnroll;
using System;
using OpenQA.Selenium.Chrome;
namespace CampusFranceBDDAuto.StepDefinitions
{
    [Binding]
    public class CreationDeCompteCampusFranceChercheur
    {

        IWebDriver driver;
        LectureFichierJson read = new LectureFichierJson();
        List<Utilisateurs> utilisateurs;
        Utilisateurs utilisateur;


        [Given("[je suis sur la pagee de création de compte Campus France]")]
        public void GivenJeSuisSurLaPageeDeCreationDeCompteCampusFrance()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.campusfrance.org/fr/user/register");

            try
            {
                Thread.Sleep(3000);

                IWebElement boutonCookies = driver.FindElement(By.Id("tarteaucitronAllAllowed"));

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].click();", boutonCookies);
            }
            catch
            {
                Console.WriteLine("Popup cookies non trouvée ou déjà fermée.");
            }
        }

        [When("[je charge les données du profil chercheur depuis le fichier Data_Chercheurs.json]")]
        public void WhenJeChargeLesDonneesDuProfilChercheurDepuisLeFichierData_Chercheurs_Json()
        {
            utilisateurs = read.ReadChercheursJson();
            utilisateur = utilisateurs[0];
        }

        [When("[je renseigne les champs lee mail , le mot de passe, et je le re confirme]")]
        public void WhenJeRenseigneLesChampsLeeMailLeMotDePasseEtJeLeReConfirme()
        {
            Thread.Sleep(2000);
            //email

            Thread.Sleep(2000);
            driver.FindElement(By.Name("pass[pass1]")).SendKeys(utilisateur.motDePasse);

            Thread.Sleep(2000);
            driver.FindElement(By.Name("pass[pass2]")).SendKeys(utilisateur.confirmationMotDePasse);

        }

        [When("[je renseigne le bouton du genre Mme ou Mr, le nom, prenom, une liste pour choisir le pays de residence]")]
        public void WhenJeRenseigneLeBoutonDuGenreMmeOuMrLeNomPrenomUneListePourChoisirLePaysDeResidence()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"edit-field-civilite\"]/div[2]/label")).Click();

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"edit-field-nom-0-value\"]")).SendKeys(utilisateur.nom);

            Thread.Sleep(2000);
            driver.FindElement(By.Id("edit-field-prenom-0-value")).SendKeys(utilisateur.prenom);

        }

        [When("[je renseigne le pays de nationalite, j ai un bouton si je veux retirer mon champ, et un autre si je veux ajouter une autre nationalite ]")]
        public void WhenJeRenseigneLePaysDeNationaliteJAiUnBoutonSiJeVeuxRetirerMonChampEtUnAutreSiJeVeuxAjouterUneAutreNationalite()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("[id^='edit-field-nationalite-0-target-id']"))
                  .SendKeys(utilisateur.paysNationalite);

            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("[id^='edit-field-nationalite-add-more']"))
                  .Click();

            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("[id^='edit-field-nationalite-1-target-id']"))
                  .SendKeys(utilisateur.paysNationalite);

        }

        [When("[je renseigne le code postal, la ville et le n telephone ]")]
        public void WhenJeRenseigneLeCodePostalLaVilleEtLeNTelephone()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.Id("edit-field-code-postal-0-value")).SendKeys(utilisateur.codePostal);

            Thread.Sleep(2000);
            driver.FindElement(By.Id("edit-field-ville-0-value")).SendKeys(utilisateur.ville);

            Thread.Sleep(2000);
            driver.FindElement(By.Id("edit-field-telephone-0-value")).SendKeys(utilisateur.telephone);

        }

        [When("[je coche la case Chercheur, je choisis dans la lsite domaine d etudes et niveau d etude ]")]
        public void WhenJeCocheLaCaseChercheurJeChoisisDansLaLsiteDomaineDEtudesEtNiveauDEtude()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"edit-field-publics-cibles\"]/div[2]/label")).Click();

            Thread.Sleep(2000);
            //SelectElement domaineetude = new SelectElement(driver.FindElement(By.XPath("//*[@id=\"edit-field-domaine-etudes-wrapper\"]/div/div/div[1]")));
            //domaineetude.SelectByText(utilisateur.domaineEtudes);

            Thread.Sleep(2000);
            //SelectElement niveauetude = new SelectElement(driver.FindElement(By.XPath("//*[@id=\"edit-field-niveaux-etude-wrapper\"]/div/div/div[1]")));
            //niveauetude.SelectByText(utilisateur.niveauEtudes);


        }

        [When("[j accepte la confidentialite des donnee ]")]
        public void WhenJAccepteLaConfidentialiteDesDonnee()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"edit-field-accepte-communications-wrapper\"]/div/label")).Click();
        }

        [Then("[le formulaire de creation de compte chercheur doit etre correctement rempli]")]
        public void ThenLeFormulaireDeCreationDeCompteChercheurDoitEtreCorrectementRempli()
        {
            Console.WriteLine("Formulaire rempli entierement");
        }

    }
}
