using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace CampusFranceBDDAuto.StepDefinitions
{
    [Binding]
    public class CreationDeCompteCampusFranceInstitutionnel
    {
        IWebDriver driver;
        LectureFichierJson read = new LectureFichierJson();
        List<Utilisateurs> utilisateurs;
        Utilisateurs utilisateur;


        [Given("[je suis sur la page de creeation de compte Campus France]")]
        public void GivenJeSuisSurLaPageDeCreeationDeCompteCampusFrance()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.campusfrance.org/fr/user/register");

            try
            {
                Thread.Sleep(4000);

                IWebElement boutonCookies = driver.FindElement(By.Id("tarteaucitronAllAllowed"));

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].click();", boutonCookies);
            }
            catch
            {
                Console.WriteLine("Popup cookies non trouvée ou déjà fermée.");
            }

        }

        [When("[je charge les données du profil institutionnel depuis le fichier Data_Institutionnel.json]")]
        public void WhenJeChargeLesDonneesDuProfilInstitutionnelDepuisLeFichierData_Institutionnel_Json()
        {
            utilisateurs = read.ReadInstitutionnelsJson();
            utilisateur = utilisateurs[0];
        }

        [When("[je renseignee les champs l email , le mot de passe, et je le re confirme]")]
        public void WhenJeRenseigneeLesChampsLEmailLeMotDePasseEtJeLeReConfirme()
        {
            Thread.Sleep(2000);
            //email

            Thread.Sleep(2000);
            driver.FindElement(By.Name("pass[pass1]")).SendKeys(utilisateur.motDePasse);

            Thread.Sleep(2000);
            driver.FindElement(By.Name("pass[pass2]")).SendKeys(utilisateur.confirmationMotDePasse);

        }

        [When("[je renseignee le btn du genre Mme ou Mr, le nom, prenom, une liste pour choisir le pays de residence]")]
        public void WhenJeRenseigneeLeBtnDuGenreMmeOuMrLeNomPrenomUneListePourChoisirLePaysDeResidence()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"edit-field-civilite\"]/div[2]/label")).Click();

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"edit-field-nom-0-value\"]")).SendKeys(utilisateur.nom);

            Thread.Sleep(2000);
            driver.FindElement(By.Id("edit-field-prenom-0-value")).SendKeys(utilisateur.prenom);

        }

        [When("[je renseigne le pays de nationalité, j ai un bouton si je veux retirer mon champ, et un autre si je veux ajouter une autre nationalite ]")]
        public void WhenJeRenseigneLePaysDeNationaliteJAiUnBoutonSiJeVeuxRetirerMonChampEtUnAutreSiJeVeuxAjouterUneAutreNationalite()
        {
            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("[id^='edit-field-nationalite-0-target-id']"))
                  .SendKeys(utilisateur.paysNationalite);

            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("[id^='edit-field-nationalite-add-more']"))
                  .Click();

            Thread.Sleep(4000);
            driver.FindElement(By.CssSelector("[id^='edit-field-nationalite-1-target-id']"))
                  .SendKeys(utilisateur.paysNationalite);

        }

        [When("[je renseignee le code postal, la ville et le numero de telephone ]")]
        public void WhenJeRenseigneeLeCodePostalLaVilleEtLeNumeroDeTelephone()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.Id("edit-field-code-postal-0-value")).SendKeys(utilisateur.codePostal);

            Thread.Sleep(2000);
            driver.FindElement(By.Id("edit-field-ville-0-value")).SendKeys(utilisateur.ville);

            Thread.Sleep(2000);
            driver.FindElement(By.Id("edit-field-telephone-0-value")).SendKeys(utilisateur.telephone);

        }

        [When("[je coche la case Institutionnel, je renseigne la fonction, je choisis le type d organisme dans la liste et je renseigne son nom ]")]
        public void WhenJeCocheLaCaseInstitutionnelJeRenseigneLaFonctionJeChoisisLeTypeDOrganismeDansLaListeEtJeRenseigneSonNom()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"edit-field-publics-cibles\"]/div[3]/label")).Click();

            Thread.Sleep(2000);
            driver.FindElement(By.Id("edit-field-fonction-0-value")).SendKeys(utilisateur.fonction);

            Thread.Sleep(2000);
            //SelectElement organisme = new SelectElement(driver.FindElement(By.CssSelector("#edit-field-type-organisme-selectized")));
            //organisme.SelectByText(utilisateur.typeOrganisme);

            Thread.Sleep(2000);
            driver.FindElement(By.Id("edit-field-nom-organisme-0-value")).SendKeys(utilisateur.nomOrganisme);

        }

        [When("[j acceptee la confidentialite des donnees ]")]
        public void WhenJAccepteeLaConfidentialiteDesDonnees()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"edit-field-accepte-communications-wrapper\"]/div/label")).Click();

        }

        [Then("[le formulaire de creation de compte Institutionnel doit etre correctement rempli]")]
        public void ThenLeFormulaireDeCreationDeCompteInstitutionnelDoitEtreCorrectementRempli()
        {
            Console.WriteLine("Formulaire rempli entierement");
        }

    }
}
