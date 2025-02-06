using Anade.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Anade.Khadamat.Domain
{
    /// <summary>
    /// Chaque classe et membre doit avoir un résumé en une phrase
    /// décrivant son objectif.
    /// </summary>
    /// <remarks>
    /// Vous pouvez développer ce résumé en une phrase pour
    /// fournir plus d'informations aux lecteurs. Dans ce cas,
    /// la <c>ExampleClass</c> fournit différents éléments C#
    /// pour montrer comment vous ajouteriez des commentaires de documentation pour la plupart des éléments d'une classe typique.
    /// <para>
    /// Les remarques peuvent ajouter plusieurs paragraphes, afin que vous puissiez
    /// écrire des informations détaillées pour les développeurs qui utilisent
    /// votre travail. Vous devez ajouter tout ce qui est nécessaire pour que les
    /// lecteurs réussissent. Cette classe contient
    /// des exemples pour les éléments suivants :
    /// </para>
    /// <list type="table">
    /// <item>
    /// <term>Summary</term>
    /// <description>
    /// Cela devrait fournir un résumé en une phrase de la classe ou du membre.
    /// </description>
    /// </item>
    /// <item>
    /// <term>Remarques</term>
    /// <description>
    /// Il s'agit généralement d'une description plus détaillée de la classe ou du membre
    /// </description>
    /// </item>
    /// <item>
    /// <term>para</term>
    /// <description>
    /// La balise para sépare une section en plusieurs paragraphes
    /// </description>
    /// </item>
    /// <item>
    /// <term>liste</term>
    /// <description>
    /// Fournit une liste de termes ou d'éléments
    /// </description>
    /// </item>
    /// <item>
    /// <term>retours, param</term>
    /// <description>
    /// Utilisé pour décrire les paramètres et renvoyer des valeurs
    /// </description>
    /// </item>
    /// <item>
    /// <term>value</term>
    /// <description>Utilisé pour décrire les propriétés</description>
    /// </item>
    /// <item>
    /// <term>exception</term>
    /// <description>
    /// Utilisé pour décrire les exceptions qui peuvent être levées
    /// </description>
    /// </item>
    /// <item>
    /// <term>c, cref, see, seealso</term>
    /// <description>
    /// Ceux-ci fournissent un style de code et des liens vers d'autres
    /// éléments de documentation
    /// </description>
    /// </item>
    /// <item>
    /// <term>example, code</term>
    /// <description>
    /// Ceux-ci sont utilisés pour les exemples de code
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// La liste ci-dessus utilise le style "table". Vous pouvez
    /// également utiliser le style "puce" ou "numéro". Aucun des deux
    /// n'utilise généralement l'élément « term ».
    /// <br/>
    /// Remarque : les paragraphes sont à double interligne. Utilisez la balise *br*
    /// pour les lignes à interligne simple.
    /// </para>
    /// </remarks>
    
    [NotMapped]
    public partial class EtatPlanTresorerieModel : IEntity<int>
    {
        /// <value>
        /// La propriété <c>Label</c> représente une étiquette
        /// pour cette instance.
        /// </value>
        /// <remarks>
        /// Le <see cref="Label"/> est un <see langword="string"/>
        /// que vous utilisez pour une étiquette.
        /// <para>
        /// Notez qu'il n'existe aucun moyen de fournir un "cref"
        /// à chaque accesseur, uniquement à la propriété elle-même.
        /// </para>
        /// </remarks>
        public int Id { get; set; }

        #region Données EtatPlanTresorerie Année01

        #region Données EtatPlanTresorerie Année01 Mois01
        public string SoldeInitial_01_01 { get; set; }
        public string ApportSupplementaire_01_01 { get; set; }
        public string CMT_01_01 { get; set; }
        public string PNRClassique_01_01 { get; set; }
        public string ApportPersonnel_01_01 { get; set; }
        public string PNRLoyer_01_01 { get; set; }
        public string EncaissementRecusClients_01_01 { get; set; }
        public string TotalRecette_01_01 { get; set; }
        public string AcquisitionEquipementAmenagement_01_01 { get; set; }
        public string DecaissementFournisseurs_01_01 { get; set; }
        public string DecaissementPrestataires_01_01 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_01_01 { get; set; }
        public string DecaissementSalairesNets_01_01 { get; set; }
        public string CotisationsSociales_01_01 { get; set; }
        public string IRGSalaires_01_01 { get; set; }
        public string TVAPayer_01_01 { get; set; }
        public string IBS_IFU_01_01 { get; set; }
        public string TotalDepense_01_01 { get; set; }
        public string SoldeFinal_01_01 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année01 Mois02
        public string SoldeInitial_01_02 { get; set; }
        public string ApportSupplementaire_01_02 { get; set; }
        public string CMT_01_02 { get; set; }
        public string PNRClassique_01_02 { get; set; }
        public string ApportPersonnel_01_02 { get; set; }
        public string PNRLoyer_01_02 { get; set; }
        public string EncaissementRecusClients_01_02 { get; set; }
        public string TotalRecette_01_02 { get; set; }
        public string AcquisitionEquipementAmenagement_01_02 { get; set; }
        public string DecaissementFournisseurs_01_02 { get; set; }
        public string DecaissementPrestataires_01_02 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_01_02 { get; set; }
        public string DecaissementSalairesNets_01_02 { get; set; }
        public string CotisationsSociales_01_02 { get; set; }
        public string IRGSalaires_01_02 { get; set; }
        public string TVAPayer_01_02 { get; set; }
        public string IBS_IFU_01_02 { get; set; }
        public string TotalDepense_01_02 { get; set; }
        public string SoldeFinal_01_02 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année01 Mois03
        public string SoldeInitial_01_03 { get; set; }
        public string ApportSupplementaire_01_03 { get; set; }
        public string CMT_01_03 { get; set; }
        public string PNRClassique_01_03 { get; set; }
        public string ApportPersonnel_01_03 { get; set; }
        public string PNRLoyer_01_03 { get; set; }
        public string EncaissementRecusClients_01_03 { get; set; }
        public string TotalRecette_01_03 { get; set; }
        public string AcquisitionEquipementAmenagement_01_03 { get; set; }
        public string DecaissementFournisseurs_01_03 { get; set; }
        public string DecaissementPrestataires_01_03 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_01_03 { get; set; }
        public string DecaissementSalairesNets_01_03 { get; set; }
        public string CotisationsSociales_01_03 { get; set; }
        public string IRGSalaires_01_03 { get; set; }
        public string TVAPayer_01_03 { get; set; }
        public string IBS_IFU_01_03 { get; set; }
        public string TotalDepense_01_03 { get; set; }
        public string SoldeFinal_01_03 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année01 Mois04
        public string SoldeInitial_01_04 { get; set; }
        public string ApportSupplementaire_01_04 { get; set; }
        public string CMT_01_04 { get; set; }
        public string PNRClassique_01_04 { get; set; }
        public string ApportPersonnel_01_04 { get; set; }
        public string PNRLoyer_01_04 { get; set; }
        public string EncaissementRecusClients_01_04 { get; set; }
        public string TotalRecette_01_04 { get; set; }
        public string AcquisitionEquipementAmenagement_01_04 { get; set; }
        public string DecaissementFournisseurs_01_04 { get; set; }
        public string DecaissementPrestataires_01_04 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_01_04 { get; set; }
        public string DecaissementSalairesNets_01_04 { get; set; }
        public string CotisationsSociales_01_04 { get; set; }
        public string IRGSalaires_01_04 { get; set; }
        public string TVAPayer_01_04 { get; set; }
        public string IBS_IFU_01_04 { get; set; }
        public string TotalDepense_01_04 { get; set; }
        public string SoldeFinal_01_04 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année01 Mois05
        public string SoldeInitial_01_05 { get; set; }
        public string ApportSupplementaire_01_05 { get; set; }
        public string CMT_01_05 { get; set; }
        public string PNRClassique_01_05 { get; set; }
        public string ApportPersonnel_01_05 { get; set; }
        public string PNRLoyer_01_05 { get; set; }
        public string EncaissementRecusClients_01_05 { get; set; }
        public string TotalRecette_01_05 { get; set; }
        public string AcquisitionEquipementAmenagement_01_05 { get; set; }
        public string DecaissementFournisseurs_01_05 { get; set; }
        public string DecaissementPrestataires_01_05 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_01_05 { get; set; }
        public string DecaissementSalairesNets_01_05 { get; set; }
        public string CotisationsSociales_01_05 { get; set; }
        public string IRGSalaires_01_05 { get; set; }
        public string TVAPayer_01_05 { get; set; }
        public string IBS_IFU_01_05 { get; set; }
        public string TotalDepense_01_05 { get; set; }
        public string SoldeFinal_01_05 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année01 Mois06
        public string SoldeInitial_01_06 { get; set; }
        public string ApportSupplementaire_01_06 { get; set; }
        public string CMT_01_06 { get; set; }
        public string PNRClassique_01_06 { get; set; }
        public string ApportPersonnel_01_06 { get; set; }
        public string PNRLoyer_01_06 { get; set; }
        public string EncaissementRecusClients_01_06 { get; set; }
        public string TotalRecette_01_06 { get; set; }
        public string AcquisitionEquipementAmenagement_01_06 { get; set; }
        public string DecaissementFournisseurs_01_06 { get; set; }
        public string DecaissementPrestataires_01_06 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_01_06 { get; set; }
        public string DecaissementSalairesNets_01_06 { get; set; }
        public string CotisationsSociales_01_06 { get; set; }
        public string IRGSalaires_01_06 { get; set; }
        public string TVAPayer_01_06 { get; set; }
        public string IBS_IFU_01_06 { get; set; }
        public string TotalDepense_01_06 { get; set; }
        public string SoldeFinal_01_06 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année01 Mois07
        public string SoldeInitial_01_07 { get; set; }
        public string ApportSupplementaire_01_07 { get; set; }
        public string CMT_01_07 { get; set; }
        public string PNRClassique_01_07 { get; set; }
        public string ApportPersonnel_01_07 { get; set; }
        public string PNRLoyer_01_07 { get; set; }
        public string EncaissementRecusClients_01_07 { get; set; }
        public string TotalRecette_01_07 { get; set; }
        public string AcquisitionEquipementAmenagement_01_07 { get; set; }
        public string DecaissementFournisseurs_01_07 { get; set; }
        public string DecaissementPrestataires_01_07 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_01_07 { get; set; }
        public string DecaissementSalairesNets_01_07 { get; set; }
        public string CotisationsSociales_01_07 { get; set; }
        public string IRGSalaires_01_07 { get; set; }
        public string TVAPayer_01_07 { get; set; }
        public string IBS_IFU_01_07 { get; set; }
        public string TotalDepense_01_07 { get; set; }
        public string SoldeFinal_01_07 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année01 Mois08
        public string SoldeInitial_01_08 { get; set; }
        public string ApportSupplementaire_01_08 { get; set; }
        public string CMT_01_08 { get; set; }
        public string PNRClassique_01_08 { get; set; }
        public string ApportPersonnel_01_08 { get; set; }
        public string PNRLoyer_01_08 { get; set; }
        public string EncaissementRecusClients_01_08 { get; set; }
        public string TotalRecette_01_08 { get; set; }
        public string AcquisitionEquipementAmenagement_01_08 { get; set; }
        public string DecaissementFournisseurs_01_08 { get; set; }
        public string DecaissementPrestataires_01_08 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_01_08 { get; set; }
        public string DecaissementSalairesNets_01_08 { get; set; }
        public string CotisationsSociales_01_08 { get; set; }
        public string IRGSalaires_01_08 { get; set; }
        public string TVAPayer_01_08 { get; set; }
        public string IBS_IFU_01_08 { get; set; }
        public string TotalDepense_01_08 { get; set; }
        public string SoldeFinal_01_08 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année01 Mois09
        public string SoldeInitial_01_09 { get; set; }
        public string ApportSupplementaire_01_09 { get; set; }
        public string CMT_01_09 { get; set; }
        public string PNRClassique_01_09 { get; set; }
        public string ApportPersonnel_01_09 { get; set; }
        public string PNRLoyer_01_09 { get; set; }
        public string EncaissementRecusClients_01_09 { get; set; }
        public string TotalRecette_01_09 { get; set; }
        public string AcquisitionEquipementAmenagement_01_09 { get; set; }
        public string DecaissementFournisseurs_01_09 { get; set; }
        public string DecaissementPrestataires_01_09 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_01_09 { get; set; }
        public string DecaissementSalairesNets_01_09 { get; set; }
        public string CotisationsSociales_01_09 { get; set; }
        public string IRGSalaires_01_09 { get; set; }
        public string TVAPayer_01_09 { get; set; }
        public string IBS_IFU_01_09 { get; set; }
        public string TotalDepense_01_09 { get; set; }
        public string SoldeFinal_01_09 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année01 Mois10
        public string SoldeInitial_01_10 { get; set; }
        public string ApportSupplementaire_01_10 { get; set; }
        public string CMT_01_10 { get; set; }
        public string PNRClassique_01_10 { get; set; }
        public string ApportPersonnel_01_10 { get; set; }
        public string PNRLoyer_01_10 { get; set; }
        public string EncaissementRecusClients_01_10 { get; set; }
        public string TotalRecette_01_10 { get; set; }
        public string AcquisitionEquipementAmenagement_01_10 { get; set; }
        public string DecaissementFournisseurs_01_10 { get; set; }
        public string DecaissementPrestataires_01_10 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_01_10 { get; set; }
        public string DecaissementSalairesNets_01_10 { get; set; }
        public string CotisationsSociales_01_10 { get; set; }
        public string IRGSalaires_01_10 { get; set; }
        public string TVAPayer_01_10 { get; set; }
        public string IBS_IFU_01_10 { get; set; }
        public string TotalDepense_01_10 { get; set; }
        public string SoldeFinal_01_10 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année01 Mois11
        public string SoldeInitial_01_11 { get; set; }
        public string ApportSupplementaire_01_11 { get; set; }
        public string CMT_01_11 { get; set; }
        public string PNRClassique_01_11 { get; set; }
        public string ApportPersonnel_01_11 { get; set; }
        public string PNRLoyer_01_11 { get; set; }
        public string EncaissementRecusClients_01_11 { get; set; }
        public string TotalRecette_01_11 { get; set; }
        public string AcquisitionEquipementAmenagement_01_11 { get; set; }
        public string DecaissementFournisseurs_01_11 { get; set; }
        public string DecaissementPrestataires_01_11 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_01_11 { get; set; }
        public string DecaissementSalairesNets_01_11 { get; set; }
        public string CotisationsSociales_01_11 { get; set; }
        public string IRGSalaires_01_11 { get; set; }
        public string TVAPayer_01_11 { get; set; }
        public string IBS_IFU_01_11 { get; set; }
        public string TotalDepense_01_11 { get; set; }
        public string SoldeFinal_01_11 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année01 Mois12
        public string SoldeInitial_01_12 { get; set; }
        public string ApportSupplementaire_01_12 { get; set; }
        public string CMT_01_12 { get; set; }
        public string PNRClassique_01_12 { get; set; }
        public string ApportPersonnel_01_12 { get; set; }
        public string PNRLoyer_01_12 { get; set; }
        public string EncaissementRecusClients_01_12 { get; set; }
        public string TotalRecette_01_12 { get; set; }
        public string AcquisitionEquipementAmenagement_01_12 { get; set; }
        public string DecaissementFournisseurs_01_12 { get; set; }
        public string DecaissementPrestataires_01_12 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_01_12 { get; set; }
        public string DecaissementSalairesNets_01_12 { get; set; }
        public string CotisationsSociales_01_12 { get; set; }
        public string IRGSalaires_01_12 { get; set; }
        public string TVAPayer_01_12 { get; set; }
        public string IBS_IFU_01_12 { get; set; }
        public string TotalDepense_01_12 { get; set; }
        public string SoldeFinal_01_12 { get; set; }
        #endregion

        #endregion

        #region Données EtatPlanTresorerie Année02

        #region Données EtatPlanTresorerie Année02 Mois01
        public string SoldeInitial_02_01 { get; set; }
        public string ApportSupplementaire_02_01 { get; set; }
        public string CMT_02_01 { get; set; }
        public string PNRClassique_02_01 { get; set; }
        public string ApportPersonnel_02_01 { get; set; }
        public string PNRLoyer_02_01 { get; set; }
        public string EncaissementRecusClients_02_01 { get; set; }
        public string TotalRecette_02_01 { get; set; }
        public string AcquisitionEquipementAmenagement_02_01 { get; set; }
        public string DecaissementFournisseurs_02_01 { get; set; }
        public string DecaissementPrestataires_02_01 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_02_01 { get; set; }
        public string DecaissementSalairesNets_02_01 { get; set; }
        public string CotisationsSociales_02_01 { get; set; }
        public string IRGSalaires_02_01 { get; set; }
        public string TVAPayer_02_01 { get; set; }
        public string IBS_IFU_02_01 { get; set; }
        public string TotalDepense_02_01 { get; set; }
        public string SoldeFinal_02_01 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année02 Mois02
        public string SoldeInitial_02_02 { get; set; }
        public string ApportSupplementaire_02_02 { get; set; }
        public string CMT_02_02 { get; set; }
        public string PNRClassique_02_02 { get; set; }
        public string ApportPersonnel_02_02 { get; set; }
        public string PNRLoyer_02_02 { get; set; }
        public string EncaissementRecusClients_02_02 { get; set; }
        public string TotalRecette_02_02 { get; set; }
        public string AcquisitionEquipementAmenagement_02_02 { get; set; }
        public string DecaissementFournisseurs_02_02 { get; set; }
        public string DecaissementPrestataires_02_02 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_02_02 { get; set; }
        public string DecaissementSalairesNets_02_02 { get; set; }
        public string CotisationsSociales_02_02 { get; set; }
        public string IRGSalaires_02_02 { get; set; }
        public string TVAPayer_02_02 { get; set; }
        public string IBS_IFU_02_02 { get; set; }
        public string TotalDepense_02_02 { get; set; }
        public string SoldeFinal_02_02 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année02 Mois03
        public string SoldeInitial_02_03 { get; set; }
        public string ApportSupplementaire_02_03 { get; set; }
        public string CMT_02_03 { get; set; }
        public string PNRClassique_02_03 { get; set; }
        public string ApportPersonnel_02_03 { get; set; }
        public string PNRLoyer_02_03 { get; set; }
        public string EncaissementRecusClients_02_03 { get; set; }
        public string TotalRecette_02_03 { get; set; }
        public string AcquisitionEquipementAmenagement_02_03 { get; set; }
        public string DecaissementFournisseurs_02_03 { get; set; }
        public string DecaissementPrestataires_02_03 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_02_03 { get; set; }
        public string DecaissementSalairesNets_02_03 { get; set; }
        public string CotisationsSociales_02_03 { get; set; }
        public string IRGSalaires_02_03 { get; set; }
        public string TVAPayer_02_03 { get; set; }
        public string IBS_IFU_02_03 { get; set; }
        public string TotalDepense_02_03 { get; set; }
        public string SoldeFinal_02_03 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année02 Mois04
        public string SoldeInitial_02_04 { get; set; }
        public string ApportSupplementaire_02_04 { get; set; }
        public string CMT_02_04 { get; set; }
        public string PNRClassique_02_04 { get; set; }
        public string ApportPersonnel_02_04 { get; set; }
        public string PNRLoyer_02_04 { get; set; }
        public string EncaissementRecusClients_02_04 { get; set; }
        public string TotalRecette_02_04 { get; set; }
        public string AcquisitionEquipementAmenagement_02_04 { get; set; }
        public string DecaissementFournisseurs_02_04 { get; set; }
        public string DecaissementPrestataires_02_04 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_02_04 { get; set; }
        public string DecaissementSalairesNets_02_04 { get; set; }
        public string CotisationsSociales_02_04 { get; set; }
        public string IRGSalaires_02_04 { get; set; }
        public string TVAPayer_02_04 { get; set; }
        public string IBS_IFU_02_04 { get; set; }
        public string TotalDepense_02_04 { get; set; }
        public string SoldeFinal_02_04 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année02 Mois05
        public string SoldeInitial_02_05 { get; set; }
        public string ApportSupplementaire_02_05 { get; set; }
        public string CMT_02_05 { get; set; }
        public string PNRClassique_02_05 { get; set; }
        public string ApportPersonnel_02_05 { get; set; }
        public string PNRLoyer_02_05 { get; set; }
        public string EncaissementRecusClients_02_05 { get; set; }
        public string TotalRecette_02_05 { get; set; }
        public string AcquisitionEquipementAmenagement_02_05 { get; set; }
        public string DecaissementFournisseurs_02_05 { get; set; }
        public string DecaissementPrestataires_02_05 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_02_05 { get; set; }
        public string DecaissementSalairesNets_02_05 { get; set; }
        public string CotisationsSociales_02_05 { get; set; }
        public string IRGSalaires_02_05 { get; set; }
        public string TVAPayer_02_05 { get; set; }
        public string IBS_IFU_02_05 { get; set; }
        public string TotalDepense_02_05 { get; set; }
        public string SoldeFinal_02_05 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année02 Mois06
        public string SoldeInitial_02_06 { get; set; }
        public string ApportSupplementaire_02_06 { get; set; }
        public string CMT_02_06 { get; set; }
        public string PNRClassique_02_06 { get; set; }
        public string ApportPersonnel_02_06 { get; set; }
        public string PNRLoyer_02_06 { get; set; }
        public string EncaissementRecusClients_02_06 { get; set; }
        public string TotalRecette_02_06 { get; set; }
        public string AcquisitionEquipementAmenagement_02_06 { get; set; }
        public string DecaissementFournisseurs_02_06 { get; set; }
        public string DecaissementPrestataires_02_06 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_02_06 { get; set; }
        public string DecaissementSalairesNets_02_06 { get; set; }
        public string CotisationsSociales_02_06 { get; set; }
        public string IRGSalaires_02_06 { get; set; }
        public string TVAPayer_02_06 { get; set; }
        public string IBS_IFU_02_06 { get; set; }
        public string TotalDepense_02_06 { get; set; }
        public string SoldeFinal_02_06 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année02 Mois07
        public string SoldeInitial_02_07 { get; set; }
        public string ApportSupplementaire_02_07 { get; set; }
        public string CMT_02_07 { get; set; }
        public string PNRClassique_02_07 { get; set; }
        public string ApportPersonnel_02_07 { get; set; }
        public string PNRLoyer_02_07 { get; set; }
        public string EncaissementRecusClients_02_07 { get; set; }
        public string TotalRecette_02_07 { get; set; }
        public string AcquisitionEquipementAmenagement_02_07 { get; set; }
        public string DecaissementFournisseurs_02_07 { get; set; }
        public string DecaissementPrestataires_02_07 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_02_07 { get; set; }
        public string DecaissementSalairesNets_02_07 { get; set; }
        public string CotisationsSociales_02_07 { get; set; }
        public string IRGSalaires_02_07 { get; set; }
        public string TVAPayer_02_07 { get; set; }
        public string IBS_IFU_02_07 { get; set; }
        public string TotalDepense_02_07 { get; set; }
        public string SoldeFinal_02_07 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année02 Mois08
        public string SoldeInitial_02_08 { get; set; }
        public string ApportSupplementaire_02_08 { get; set; }
        public string CMT_02_08 { get; set; }
        public string PNRClassique_02_08 { get; set; }
        public string ApportPersonnel_02_08 { get; set; }
        public string PNRLoyer_02_08 { get; set; }
        public string EncaissementRecusClients_02_08 { get; set; }
        public string TotalRecette_02_08 { get; set; }
        public string AcquisitionEquipementAmenagement_02_08 { get; set; }
        public string DecaissementFournisseurs_02_08 { get; set; }
        public string DecaissementPrestataires_02_08 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_02_08 { get; set; }
        public string DecaissementSalairesNets_02_08 { get; set; }
        public string CotisationsSociales_02_08 { get; set; }
        public string IRGSalaires_02_08 { get; set; }
        public string TVAPayer_02_08 { get; set; }
        public string IBS_IFU_02_08 { get; set; }
        public string TotalDepense_02_08 { get; set; }
        public string SoldeFinal_02_08 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année02 Mois09
        public string SoldeInitial_02_09 { get; set; }
        public string ApportSupplementaire_02_09 { get; set; }
        public string CMT_02_09 { get; set; }
        public string PNRClassique_02_09 { get; set; }
        public string ApportPersonnel_02_09 { get; set; }
        public string PNRLoyer_02_09 { get; set; }
        public string EncaissementRecusClients_02_09 { get; set; }
        public string TotalRecette_02_09 { get; set; }
        public string AcquisitionEquipementAmenagement_02_09 { get; set; }
        public string DecaissementFournisseurs_02_09 { get; set; }
        public string DecaissementPrestataires_02_09 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_02_09 { get; set; }
        public string DecaissementSalairesNets_02_09 { get; set; }
        public string CotisationsSociales_02_09 { get; set; }
        public string IRGSalaires_02_09 { get; set; }
        public string TVAPayer_02_09 { get; set; }
        public string IBS_IFU_02_09 { get; set; }
        public string TotalDepense_02_09 { get; set; }
        public string SoldeFinal_02_09 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année02 Mois10
        public string SoldeInitial_02_10 { get; set; }
        public string ApportSupplementaire_02_10 { get; set; }
        public string CMT_02_10 { get; set; }
        public string PNRClassique_02_10 { get; set; }
        public string ApportPersonnel_02_10 { get; set; }
        public string PNRLoyer_02_10 { get; set; }
        public string EncaissementRecusClients_02_10 { get; set; }
        public string TotalRecette_02_10 { get; set; }
        public string AcquisitionEquipementAmenagement_02_10 { get; set; }
        public string DecaissementFournisseurs_02_10 { get; set; }
        public string DecaissementPrestataires_02_10 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_02_10 { get; set; }
        public string DecaissementSalairesNets_02_10 { get; set; }
        public string CotisationsSociales_02_10 { get; set; }
        public string IRGSalaires_02_10 { get; set; }
        public string TVAPayer_02_10 { get; set; }
        public string IBS_IFU_02_10 { get; set; }
        public string TotalDepense_02_10 { get; set; }
        public string SoldeFinal_02_10 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année02 Mois11
        public string SoldeInitial_02_11 { get; set; }
        public string ApportSupplementaire_02_11 { get; set; }
        public string CMT_02_11 { get; set; }
        public string PNRClassique_02_11 { get; set; }
        public string ApportPersonnel_02_11 { get; set; }
        public string PNRLoyer_02_11 { get; set; }
        public string EncaissementRecusClients_02_11 { get; set; }
        public string TotalRecette_02_11 { get; set; }
        public string AcquisitionEquipementAmenagement_02_11 { get; set; }
        public string DecaissementFournisseurs_02_11 { get; set; }
        public string DecaissementPrestataires_02_11 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_02_11 { get; set; }
        public string DecaissementSalairesNets_02_11 { get; set; }
        public string CotisationsSociales_02_11 { get; set; }
        public string IRGSalaires_02_11 { get; set; }
        public string TVAPayer_02_11 { get; set; }
        public string IBS_IFU_02_11 { get; set; }
        public string TotalDepense_02_11 { get; set; }
        public string SoldeFinal_02_11 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année02 Mois12
        public string SoldeInitial_02_12 { get; set; }
        public string ApportSupplementaire_02_12 { get; set; }
        public string CMT_02_12 { get; set; }
        public string PNRClassique_02_12 { get; set; }
        public string ApportPersonnel_02_12 { get; set; }
        public string PNRLoyer_02_12 { get; set; }
        public string EncaissementRecusClients_02_12 { get; set; }
        public string TotalRecette_02_12 { get; set; }
        public string AcquisitionEquipementAmenagement_02_12 { get; set; }
        public string DecaissementFournisseurs_02_12 { get; set; }
        public string DecaissementPrestataires_02_12 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_02_12 { get; set; }
        public string DecaissementSalairesNets_02_12 { get; set; }
        public string CotisationsSociales_02_12 { get; set; }
        public string IRGSalaires_02_12 { get; set; }
        public string TVAPayer_02_12 { get; set; }
        public string IBS_IFU_02_12 { get; set; }
        public string TotalDepense_02_12 { get; set; }
        public string SoldeFinal_02_12 { get; set; }
        #endregion

        #endregion

        #region Données EtatPlanTresorerie Année03

        #region Données EtatPlanTresorerie Année03 Mois01
        public string SoldeInitial_03_01 { get; set; }
        public string ApportSupplementaire_03_01 { get; set; }
        public string CMT_03_01 { get; set; }
        public string PNRClassique_03_01 { get; set; }
        public string ApportPersonnel_03_01 { get; set; }
        public string PNRLoyer_03_01 { get; set; }
        public string EncaissementRecusClients_03_01 { get; set; }
        public string TotalRecette_03_01 { get; set; }
        public string AcquisitionEquipementAmenagement_03_01 { get; set; }
        public string DecaissementFournisseurs_03_01 { get; set; }
        public string DecaissementPrestataires_03_01 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_03_01 { get; set; }
        public string DecaissementSalairesNets_03_01 { get; set; }
        public string CotisationsSociales_03_01 { get; set; }
        public string IRGSalaires_03_01 { get; set; }
        public string TVAPayer_03_01 { get; set; }
        public string IBS_IFU_03_01 { get; set; }
        public string TotalDepense_03_01 { get; set; }
        public string SoldeFinal_03_01 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année03 Mois02
        public string SoldeInitial_03_02 { get; set; }
        public string ApportSupplementaire_03_02 { get; set; }
        public string CMT_03_02 { get; set; }
        public string PNRClassique_03_02 { get; set; }
        public string ApportPersonnel_03_02 { get; set; }
        public string PNRLoyer_03_02 { get; set; }
        public string EncaissementRecusClients_03_02 { get; set; }
        public string TotalRecette_03_02 { get; set; }
        public string AcquisitionEquipementAmenagement_03_02 { get; set; }
        public string DecaissementFournisseurs_03_02 { get; set; }
        public string DecaissementPrestataires_03_02 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_03_02 { get; set; }
        public string DecaissementSalairesNets_03_02 { get; set; }
        public string CotisationsSociales_03_02 { get; set; }
        public string IRGSalaires_03_02 { get; set; }
        public string TVAPayer_03_02 { get; set; }
        public string IBS_IFU_03_02 { get; set; }
        public string TotalDepense_03_02 { get; set; }
        public string SoldeFinal_03_02 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année03 Mois03
        public string SoldeInitial_03_03 { get; set; }
        public string ApportSupplementaire_03_03 { get; set; }
        public string CMT_03_03 { get; set; }
        public string PNRClassique_03_03 { get; set; }
        public string ApportPersonnel_03_03 { get; set; }
        public string PNRLoyer_03_03 { get; set; }
        public string EncaissementRecusClients_03_03 { get; set; }
        public string TotalRecette_03_03 { get; set; }
        public string AcquisitionEquipementAmenagement_03_03 { get; set; }
        public string DecaissementFournisseurs_03_03 { get; set; }
        public string DecaissementPrestataires_03_03 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_03_03 { get; set; }
        public string DecaissementSalairesNets_03_03 { get; set; }
        public string CotisationsSociales_03_03 { get; set; }
        public string IRGSalaires_03_03 { get; set; }
        public string TVAPayer_03_03 { get; set; }
        public string IBS_IFU_03_03 { get; set; }
        public string TotalDepense_03_03 { get; set; }
        public string SoldeFinal_03_03 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année03 Mois04
        public string SoldeInitial_03_04 { get; set; }
        public string ApportSupplementaire_03_04 { get; set; }
        public string CMT_03_04 { get; set; }
        public string PNRClassique_03_04 { get; set; }
        public string ApportPersonnel_03_04 { get; set; }
        public string PNRLoyer_03_04 { get; set; }
        public string EncaissementRecusClients_03_04 { get; set; }
        public string TotalRecette_03_04 { get; set; }
        public string AcquisitionEquipementAmenagement_03_04 { get; set; }
        public string DecaissementFournisseurs_03_04 { get; set; }
        public string DecaissementPrestataires_03_04 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_03_04 { get; set; }
        public string DecaissementSalairesNets_03_04 { get; set; }
        public string CotisationsSociales_03_04 { get; set; }
        public string IRGSalaires_03_04 { get; set; }
        public string TVAPayer_03_04 { get; set; }
        public string IBS_IFU_03_04 { get; set; }
        public string TotalDepense_03_04 { get; set; }
        public string SoldeFinal_03_04 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année03 Mois05
        public string SoldeInitial_03_05 { get; set; }
        public string ApportSupplementaire_03_05 { get; set; }
        public string CMT_03_05 { get; set; }
        public string PNRClassique_03_05 { get; set; }
        public string ApportPersonnel_03_05 { get; set; }
        public string PNRLoyer_03_05 { get; set; }
        public string EncaissementRecusClients_03_05 { get; set; }
        public string TotalRecette_03_05 { get; set; }
        public string AcquisitionEquipementAmenagement_03_05 { get; set; }
        public string DecaissementFournisseurs_03_05 { get; set; }
        public string DecaissementPrestataires_03_05 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_03_05 { get; set; }
        public string DecaissementSalairesNets_03_05 { get; set; }
        public string CotisationsSociales_03_05 { get; set; }
        public string IRGSalaires_03_05 { get; set; }
        public string TVAPayer_03_05 { get; set; }
        public string IBS_IFU_03_05 { get; set; }
        public string TotalDepense_03_05 { get; set; }
        public string SoldeFinal_03_05 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année03 Mois06
        public string SoldeInitial_03_06 { get; set; }
        public string ApportSupplementaire_03_06 { get; set; }
        public string CMT_03_06 { get; set; }
        public string PNRClassique_03_06 { get; set; }
        public string ApportPersonnel_03_06 { get; set; }
        public string PNRLoyer_03_06 { get; set; }
        public string EncaissementRecusClients_03_06 { get; set; }
        public string TotalRecette_03_06 { get; set; }
        public string AcquisitionEquipementAmenagement_03_06 { get; set; }
        public string DecaissementFournisseurs_03_06 { get; set; }
        public string DecaissementPrestataires_03_06 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_03_06 { get; set; }
        public string DecaissementSalairesNets_03_06 { get; set; }
        public string CotisationsSociales_03_06 { get; set; }
        public string IRGSalaires_03_06 { get; set; }
        public string TVAPayer_03_06 { get; set; }
        public string IBS_IFU_03_06 { get; set; }
        public string TotalDepense_03_06 { get; set; }
        public string SoldeFinal_03_06 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année03 Mois07
        public string SoldeInitial_03_07 { get; set; }
        public string ApportSupplementaire_03_07 { get; set; }
        public string CMT_03_07 { get; set; }
        public string PNRClassique_03_07 { get; set; }
        public string ApportPersonnel_03_07 { get; set; }
        public string PNRLoyer_03_07 { get; set; }
        public string EncaissementRecusClients_03_07 { get; set; }
        public string TotalRecette_03_07 { get; set; }
        public string AcquisitionEquipementAmenagement_03_07 { get; set; }
        public string DecaissementFournisseurs_03_07 { get; set; }
        public string DecaissementPrestataires_03_07 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_03_07 { get; set; }
        public string DecaissementSalairesNets_03_07 { get; set; }
        public string CotisationsSociales_03_07 { get; set; }
        public string IRGSalaires_03_07 { get; set; }
        public string TVAPayer_03_07 { get; set; }
        public string IBS_IFU_03_07 { get; set; }
        public string TotalDepense_03_07 { get; set; }
        public string SoldeFinal_03_07 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année03 Mois08
        public string SoldeInitial_03_08 { get; set; }
        public string ApportSupplementaire_03_08 { get; set; }
        public string CMT_03_08 { get; set; }
        public string PNRClassique_03_08 { get; set; }
        public string ApportPersonnel_03_08 { get; set; }
        public string PNRLoyer_03_08 { get; set; }
        public string EncaissementRecusClients_03_08 { get; set; }
        public string TotalRecette_03_08 { get; set; }
        public string AcquisitionEquipementAmenagement_03_08 { get; set; }
        public string DecaissementFournisseurs_03_08 { get; set; }
        public string DecaissementPrestataires_03_08 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_03_08 { get; set; }
        public string DecaissementSalairesNets_03_08 { get; set; }
        public string CotisationsSociales_03_08 { get; set; }
        public string IRGSalaires_03_08 { get; set; }
        public string TVAPayer_03_08 { get; set; }
        public string IBS_IFU_03_08 { get; set; }
        public string TotalDepense_03_08 { get; set; }
        public string SoldeFinal_03_08 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année03 Mois09
        public string SoldeInitial_03_09 { get; set; }
        public string ApportSupplementaire_03_09 { get; set; }
        public string CMT_03_09 { get; set; }
        public string PNRClassique_03_09 { get; set; }
        public string ApportPersonnel_03_09 { get; set; }
        public string PNRLoyer_03_09 { get; set; }
        public string EncaissementRecusClients_03_09 { get; set; }
        public string TotalRecette_03_09 { get; set; }
        public string AcquisitionEquipementAmenagement_03_09 { get; set; }
        public string DecaissementFournisseurs_03_09 { get; set; }
        public string DecaissementPrestataires_03_09 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_03_09 { get; set; }
        public string DecaissementSalairesNets_03_09 { get; set; }
        public string CotisationsSociales_03_09 { get; set; }
        public string IRGSalaires_03_09 { get; set; }
        public string TVAPayer_03_09 { get; set; }
        public string IBS_IFU_03_09 { get; set; }
        public string TotalDepense_03_09 { get; set; }
        public string SoldeFinal_03_09 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année03 Mois10
        public string SoldeInitial_03_10 { get; set; }
        public string ApportSupplementaire_03_10 { get; set; }
        public string CMT_03_10 { get; set; }
        public string PNRClassique_03_10 { get; set; }
        public string ApportPersonnel_03_10 { get; set; }
        public string PNRLoyer_03_10 { get; set; }
        public string EncaissementRecusClients_03_10 { get; set; }
        public string TotalRecette_03_10 { get; set; }
        public string AcquisitionEquipementAmenagement_03_10 { get; set; }
        public string DecaissementFournisseurs_03_10 { get; set; }
        public string DecaissementPrestataires_03_10 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_03_10 { get; set; }
        public string DecaissementSalairesNets_03_10 { get; set; }
        public string CotisationsSociales_03_10 { get; set; }
        public string IRGSalaires_03_10 { get; set; }
        public string TVAPayer_03_10 { get; set; }
        public string IBS_IFU_03_10 { get; set; }
        public string TotalDepense_03_10 { get; set; }
        public string SoldeFinal_03_10 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année03 Mois11
        public string SoldeInitial_03_11 { get; set; }
        public string ApportSupplementaire_03_11 { get; set; }
        public string CMT_03_11 { get; set; }
        public string PNRClassique_03_11 { get; set; }
        public string ApportPersonnel_03_11 { get; set; }
        public string PNRLoyer_03_11 { get; set; }
        public string EncaissementRecusClients_03_11 { get; set; }
        public string TotalRecette_03_11 { get; set; }
        public string AcquisitionEquipementAmenagement_03_11 { get; set; }
        public string DecaissementFournisseurs_03_11 { get; set; }
        public string DecaissementPrestataires_03_11 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_03_11 { get; set; }
        public string DecaissementSalairesNets_03_11 { get; set; }
        public string CotisationsSociales_03_11 { get; set; }
        public string IRGSalaires_03_11 { get; set; }
        public string TVAPayer_03_11 { get; set; }
        public string IBS_IFU_03_11 { get; set; }
        public string TotalDepense_03_11 { get; set; }
        public string SoldeFinal_03_11 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année03 Mois12
        public string SoldeInitial_03_12 { get; set; }
        public string ApportSupplementaire_03_12 { get; set; }
        public string CMT_03_12 { get; set; }
        public string PNRClassique_03_12 { get; set; }
        public string ApportPersonnel_03_12 { get; set; }
        public string PNRLoyer_03_12 { get; set; }
        public string EncaissementRecusClients_03_12 { get; set; }
        public string TotalRecette_03_12 { get; set; }
        public string AcquisitionEquipementAmenagement_03_12 { get; set; }
        public string DecaissementFournisseurs_03_12 { get; set; }
        public string DecaissementPrestataires_03_12 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_03_12 { get; set; }
        public string DecaissementSalairesNets_03_12 { get; set; }
        public string CotisationsSociales_03_12 { get; set; }
        public string IRGSalaires_03_12 { get; set; }
        public string TVAPayer_03_12 { get; set; }
        public string IBS_IFU_03_12 { get; set; }
        public string TotalDepense_03_12 { get; set; }
        public string SoldeFinal_03_12 { get; set; }
        #endregion

        #endregion

        #region Données EtatPlanTresorerie Année04

        #region Données EtatPlanTresorerie Année04 Mois01
        public string SoldeInitial_04_01 { get; set; }
        public string ApportSupplementaire_04_01 { get; set; }
        public string CMT_04_01 { get; set; }
        public string PNRClassique_04_01 { get; set; }
        public string ApportPersonnel_04_01 { get; set; }
        public string PNRLoyer_04_01 { get; set; }
        public string EncaissementRecusClients_04_01 { get; set; }
        public string TotalRecette_04_01 { get; set; }
        public string AcquisitionEquipementAmenagement_04_01 { get; set; }
        public string DecaissementFournisseurs_04_01 { get; set; }
        public string DecaissementPrestataires_04_01 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_04_01 { get; set; }
        public string DecaissementSalairesNets_04_01 { get; set; }
        public string CotisationsSociales_04_01 { get; set; }
        public string IRGSalaires_04_01 { get; set; }
        public string TVAPayer_04_01 { get; set; }
        public string IBS_IFU_04_01 { get; set; }
        public string TotalDepense_04_01 { get; set; }
        public string SoldeFinal_04_01 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année04 Mois02
        public string SoldeInitial_04_02 { get; set; }
        public string ApportSupplementaire_04_02 { get; set; }
        public string CMT_04_02 { get; set; }
        public string PNRClassique_04_02 { get; set; }
        public string ApportPersonnel_04_02 { get; set; }
        public string PNRLoyer_04_02 { get; set; }
        public string EncaissementRecusClients_04_02 { get; set; }
        public string TotalRecette_04_02 { get; set; }
        public string AcquisitionEquipementAmenagement_04_02 { get; set; }
        public string DecaissementFournisseurs_04_02 { get; set; }
        public string DecaissementPrestataires_04_02 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_04_02 { get; set; }
        public string DecaissementSalairesNets_04_02 { get; set; }
        public string CotisationsSociales_04_02 { get; set; }
        public string IRGSalaires_04_02 { get; set; }
        public string TVAPayer_04_02 { get; set; }
        public string IBS_IFU_04_02 { get; set; }
        public string TotalDepense_04_02 { get; set; }
        public string SoldeFinal_04_02 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année04 Mois03
        public string SoldeInitial_04_03 { get; set; }
        public string ApportSupplementaire_04_03 { get; set; }
        public string CMT_04_03 { get; set; }
        public string PNRClassique_04_03 { get; set; }
        public string ApportPersonnel_04_03 { get; set; }
        public string PNRLoyer_04_03 { get; set; }
        public string EncaissementRecusClients_04_03 { get; set; }
        public string TotalRecette_04_03 { get; set; }
        public string AcquisitionEquipementAmenagement_04_03 { get; set; }
        public string DecaissementFournisseurs_04_03 { get; set; }
        public string DecaissementPrestataires_04_03 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_04_03 { get; set; }
        public string DecaissementSalairesNets_04_03 { get; set; }
        public string CotisationsSociales_04_03 { get; set; }
        public string IRGSalaires_04_03 { get; set; }
        public string TVAPayer_04_03 { get; set; }
        public string IBS_IFU_04_03 { get; set; }
        public string TotalDepense_04_03 { get; set; }
        public string SoldeFinal_04_03 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année04 Mois04
        public string SoldeInitial_04_04 { get; set; }
        public string ApportSupplementaire_04_04 { get; set; }
        public string CMT_04_04 { get; set; }
        public string PNRClassique_04_04 { get; set; }
        public string ApportPersonnel_04_04 { get; set; }
        public string PNRLoyer_04_04 { get; set; }
        public string EncaissementRecusClients_04_04 { get; set; }
        public string TotalRecette_04_04 { get; set; }
        public string AcquisitionEquipementAmenagement_04_04 { get; set; }
        public string DecaissementFournisseurs_04_04 { get; set; }
        public string DecaissementPrestataires_04_04 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_04_04 { get; set; }
        public string DecaissementSalairesNets_04_04 { get; set; }
        public string CotisationsSociales_04_04 { get; set; }
        public string IRGSalaires_04_04 { get; set; }
        public string TVAPayer_04_04 { get; set; }
        public string IBS_IFU_04_04 { get; set; }
        public string TotalDepense_04_04 { get; set; }
        public string SoldeFinal_04_04 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année04 Mois05
        public string SoldeInitial_04_05 { get; set; }
        public string ApportSupplementaire_04_05 { get; set; }
        public string CMT_04_05 { get; set; }
        public string PNRClassique_04_05 { get; set; }
        public string ApportPersonnel_04_05 { get; set; }
        public string PNRLoyer_04_05 { get; set; }
        public string EncaissementRecusClients_04_05 { get; set; }
        public string TotalRecette_04_05 { get; set; }
        public string AcquisitionEquipementAmenagement_04_05 { get; set; }
        public string DecaissementFournisseurs_04_05 { get; set; }
        public string DecaissementPrestataires_04_05 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_04_05 { get; set; }
        public string DecaissementSalairesNets_04_05 { get; set; }
        public string CotisationsSociales_04_05 { get; set; }
        public string IRGSalaires_04_05 { get; set; }
        public string TVAPayer_04_05 { get; set; }
        public string IBS_IFU_04_05 { get; set; }
        public string TotalDepense_04_05 { get; set; }
        public string SoldeFinal_04_05 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année04 Mois06
        public string SoldeInitial_04_06 { get; set; }
        public string ApportSupplementaire_04_06 { get; set; }
        public string CMT_04_06 { get; set; }
        public string PNRClassique_04_06 { get; set; }
        public string ApportPersonnel_04_06 { get; set; }
        public string PNRLoyer_04_06 { get; set; }
        public string EncaissementRecusClients_04_06 { get; set; }
        public string TotalRecette_04_06 { get; set; }
        public string AcquisitionEquipementAmenagement_04_06 { get; set; }
        public string DecaissementFournisseurs_04_06 { get; set; }
        public string DecaissementPrestataires_04_06 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_04_06 { get; set; }
        public string DecaissementSalairesNets_04_06 { get; set; }
        public string CotisationsSociales_04_06 { get; set; }
        public string IRGSalaires_04_06 { get; set; }
        public string TVAPayer_04_06 { get; set; }
        public string IBS_IFU_04_06 { get; set; }
        public string TotalDepense_04_06 { get; set; }
        public string SoldeFinal_04_06 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année04 Mois07
        public string SoldeInitial_04_07 { get; set; }
        public string ApportSupplementaire_04_07 { get; set; }
        public string CMT_04_07 { get; set; }
        public string PNRClassique_04_07 { get; set; }
        public string ApportPersonnel_04_07 { get; set; }
        public string PNRLoyer_04_07 { get; set; }
        public string EncaissementRecusClients_04_07 { get; set; }
        public string TotalRecette_04_07 { get; set; }
        public string AcquisitionEquipementAmenagement_04_07 { get; set; }
        public string DecaissementFournisseurs_04_07 { get; set; }
        public string DecaissementPrestataires_04_07 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_04_07 { get; set; }
        public string DecaissementSalairesNets_04_07 { get; set; }
        public string CotisationsSociales_04_07 { get; set; }
        public string IRGSalaires_04_07 { get; set; }
        public string TVAPayer_04_07 { get; set; }
        public string IBS_IFU_04_07 { get; set; }
        public string TotalDepense_04_07 { get; set; }
        public string SoldeFinal_04_07 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année04 Mois08
        public string SoldeInitial_04_08 { get; set; }
        public string ApportSupplementaire_04_08 { get; set; }
        public string CMT_04_08 { get; set; }
        public string PNRClassique_04_08 { get; set; }
        public string ApportPersonnel_04_08 { get; set; }
        public string PNRLoyer_04_08 { get; set; }
        public string EncaissementRecusClients_04_08 { get; set; }
        public string TotalRecette_04_08 { get; set; }
        public string AcquisitionEquipementAmenagement_04_08 { get; set; }
        public string DecaissementFournisseurs_04_08 { get; set; }
        public string DecaissementPrestataires_04_08 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_04_08 { get; set; }
        public string DecaissementSalairesNets_04_08 { get; set; }
        public string CotisationsSociales_04_08 { get; set; }
        public string IRGSalaires_04_08 { get; set; }
        public string TVAPayer_04_08 { get; set; }
        public string IBS_IFU_04_08 { get; set; }
        public string TotalDepense_04_08 { get; set; }
        public string SoldeFinal_04_08 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année04 Mois09
        public string SoldeInitial_04_09 { get; set; }
        public string ApportSupplementaire_04_09 { get; set; }
        public string CMT_04_09 { get; set; }
        public string PNRClassique_04_09 { get; set; }
        public string ApportPersonnel_04_09 { get; set; }
        public string PNRLoyer_04_09 { get; set; }
        public string EncaissementRecusClients_04_09 { get; set; }
        public string TotalRecette_04_09 { get; set; }
        public string AcquisitionEquipementAmenagement_04_09 { get; set; }
        public string DecaissementFournisseurs_04_09 { get; set; }
        public string DecaissementPrestataires_04_09 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_04_09 { get; set; }
        public string DecaissementSalairesNets_04_09 { get; set; }
        public string CotisationsSociales_04_09 { get; set; }
        public string IRGSalaires_04_09 { get; set; }
        public string TVAPayer_04_09 { get; set; }
        public string IBS_IFU_04_09 { get; set; }
        public string TotalDepense_04_09 { get; set; }
        public string SoldeFinal_04_09 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année04 Mois10
        public string SoldeInitial_04_10 { get; set; }
        public string ApportSupplementaire_04_10 { get; set; }
        public string CMT_04_10 { get; set; }
        public string PNRClassique_04_10 { get; set; }
        public string ApportPersonnel_04_10 { get; set; }
        public string PNRLoyer_04_10 { get; set; }
        public string EncaissementRecusClients_04_10 { get; set; }
        public string TotalRecette_04_10 { get; set; }
        public string AcquisitionEquipementAmenagement_04_10 { get; set; }
        public string DecaissementFournisseurs_04_10 { get; set; }
        public string DecaissementPrestataires_04_10 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_04_10 { get; set; }
        public string DecaissementSalairesNets_04_10 { get; set; }
        public string CotisationsSociales_04_10 { get; set; }
        public string IRGSalaires_04_10 { get; set; }
        public string TVAPayer_04_10 { get; set; }
        public string IBS_IFU_04_10 { get; set; }
        public string TotalDepense_04_10 { get; set; }
        public string SoldeFinal_04_10 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année04 Mois11
        public string SoldeInitial_04_11 { get; set; }
        public string ApportSupplementaire_04_11 { get; set; }
        public string CMT_04_11 { get; set; }
        public string PNRClassique_04_11 { get; set; }
        public string ApportPersonnel_04_11 { get; set; }
        public string PNRLoyer_04_11 { get; set; }
        public string EncaissementRecusClients_04_11 { get; set; }
        public string TotalRecette_04_11 { get; set; }
        public string AcquisitionEquipementAmenagement_04_11 { get; set; }
        public string DecaissementFournisseurs_04_11 { get; set; }
        public string DecaissementPrestataires_04_11 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_04_11 { get; set; }
        public string DecaissementSalairesNets_04_11 { get; set; }
        public string CotisationsSociales_04_11 { get; set; }
        public string IRGSalaires_04_11 { get; set; }
        public string TVAPayer_04_11 { get; set; }
        public string IBS_IFU_04_11 { get; set; }
        public string TotalDepense_04_11 { get; set; }
        public string SoldeFinal_04_11 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année04 Mois12
        public string SoldeInitial_04_12 { get; set; }
        public string ApportSupplementaire_04_12 { get; set; }
        public string CMT_04_12 { get; set; }
        public string PNRClassique_04_12 { get; set; }
        public string ApportPersonnel_04_12 { get; set; }
        public string PNRLoyer_04_12 { get; set; }
        public string EncaissementRecusClients_04_12 { get; set; }
        public string TotalRecette_04_12 { get; set; }
        public string AcquisitionEquipementAmenagement_04_12 { get; set; }
        public string DecaissementFournisseurs_04_12 { get; set; }
        public string DecaissementPrestataires_04_12 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_04_12 { get; set; }
        public string DecaissementSalairesNets_04_12 { get; set; }
        public string CotisationsSociales_04_12 { get; set; }
        public string IRGSalaires_04_12 { get; set; }
        public string TVAPayer_04_12 { get; set; }
        public string IBS_IFU_04_12 { get; set; }
        public string TotalDepense_04_12 { get; set; }
        public string SoldeFinal_04_12 { get; set; }
        #endregion

        #endregion

        #region Données EtatPlanTresorerie Année05

        #region Données EtatPlanTresorerie Année05 Mois01
        public string SoldeInitial_05_01 { get; set; }
        public string ApportSupplementaire_05_01 { get; set; }
        public string CMT_05_01 { get; set; }
        public string PNRClassique_05_01 { get; set; }
        public string ApportPersonnel_05_01 { get; set; }
        public string PNRLoyer_05_01 { get; set; }
        public string EncaissementRecusClients_05_01 { get; set; }
        public string TotalRecette_05_01 { get; set; }
        public string AcquisitionEquipementAmenagement_05_01 { get; set; }
        public string DecaissementFournisseurs_05_01 { get; set; }
        public string DecaissementPrestataires_05_01 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_05_01 { get; set; }
        public string DecaissementSalairesNets_05_01 { get; set; }
        public string CotisationsSociales_05_01 { get; set; }
        public string IRGSalaires_05_01 { get; set; }
        public string TVAPayer_05_01 { get; set; }
        public string IBS_IFU_05_01 { get; set; }
        public string TotalDepense_05_01 { get; set; }
        public string SoldeFinal_05_01 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année05 Mois02
        public string SoldeInitial_05_02 { get; set; }
        public string ApportSupplementaire_05_02 { get; set; }
        public string CMT_05_02 { get; set; }
        public string PNRClassique_05_02 { get; set; }
        public string ApportPersonnel_05_02 { get; set; }
        public string PNRLoyer_05_02 { get; set; }
        public string EncaissementRecusClients_05_02 { get; set; }
        public string TotalRecette_05_02 { get; set; }
        public string AcquisitionEquipementAmenagement_05_02 { get; set; }
        public string DecaissementFournisseurs_05_02 { get; set; }
        public string DecaissementPrestataires_05_02 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_05_02 { get; set; }
        public string DecaissementSalairesNets_05_02 { get; set; }
        public string CotisationsSociales_05_02 { get; set; }
        public string IRGSalaires_05_02 { get; set; }
        public string TVAPayer_05_02 { get; set; }
        public string IBS_IFU_05_02 { get; set; }
        public string TotalDepense_05_02 { get; set; }
        public string SoldeFinal_05_02 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année05 Mois03
        public string SoldeInitial_05_03 { get; set; }
        public string ApportSupplementaire_05_03 { get; set; }
        public string CMT_05_03 { get; set; }
        public string PNRClassique_05_03 { get; set; }
        public string ApportPersonnel_05_03 { get; set; }
        public string PNRLoyer_05_03 { get; set; }
        public string EncaissementRecusClients_05_03 { get; set; }
        public string TotalRecette_05_03 { get; set; }
        public string AcquisitionEquipementAmenagement_05_03 { get; set; }
        public string DecaissementFournisseurs_05_03 { get; set; }
        public string DecaissementPrestataires_05_03 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_05_03 { get; set; }
        public string DecaissementSalairesNets_05_03 { get; set; }
        public string CotisationsSociales_05_03 { get; set; }
        public string IRGSalaires_05_03 { get; set; }
        public string TVAPayer_05_03 { get; set; }
        public string IBS_IFU_05_03 { get; set; }
        public string TotalDepense_05_03 { get; set; }
        public string SoldeFinal_05_03 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année05 Mois04
        public string SoldeInitial_05_04 { get; set; }
        public string ApportSupplementaire_05_04 { get; set; }
        public string CMT_05_04 { get; set; }
        public string PNRClassique_05_04 { get; set; }
        public string ApportPersonnel_05_04 { get; set; }
        public string PNRLoyer_05_04 { get; set; }
        public string EncaissementRecusClients_05_04 { get; set; }
        public string TotalRecette_05_04 { get; set; }
        public string AcquisitionEquipementAmenagement_05_04 { get; set; }
        public string DecaissementFournisseurs_05_04 { get; set; }
        public string DecaissementPrestataires_05_04 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_05_04 { get; set; }
        public string DecaissementSalairesNets_05_04 { get; set; }
        public string CotisationsSociales_05_04 { get; set; }
        public string IRGSalaires_05_04 { get; set; }
        public string TVAPayer_05_04 { get; set; }
        public string IBS_IFU_05_04 { get; set; }
        public string TotalDepense_05_04 { get; set; }
        public string SoldeFinal_05_04 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année05 Mois05
        public string SoldeInitial_05_05 { get; set; }
        public string ApportSupplementaire_05_05 { get; set; }
        public string CMT_05_05 { get; set; }
        public string PNRClassique_05_05 { get; set; }
        public string ApportPersonnel_05_05 { get; set; }
        public string PNRLoyer_05_05 { get; set; }
        public string EncaissementRecusClients_05_05 { get; set; }
        public string TotalRecette_05_05 { get; set; }
        public string AcquisitionEquipementAmenagement_05_05 { get; set; }
        public string DecaissementFournisseurs_05_05 { get; set; }
        public string DecaissementPrestataires_05_05 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_05_05 { get; set; }
        public string DecaissementSalairesNets_05_05 { get; set; }
        public string CotisationsSociales_05_05 { get; set; }
        public string IRGSalaires_05_05 { get; set; }
        public string TVAPayer_05_05 { get; set; }
        public string IBS_IFU_05_05 { get; set; }
        public string TotalDepense_05_05 { get; set; }
        public string SoldeFinal_05_05 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année05 Mois06
        public string SoldeInitial_05_06 { get; set; }
        public string ApportSupplementaire_05_06 { get; set; }
        public string CMT_05_06 { get; set; }
        public string PNRClassique_05_06 { get; set; }
        public string ApportPersonnel_05_06 { get; set; }
        public string PNRLoyer_05_06 { get; set; }
        public string EncaissementRecusClients_05_06 { get; set; }
        public string TotalRecette_05_06 { get; set; }
        public string AcquisitionEquipementAmenagement_05_06 { get; set; }
        public string DecaissementFournisseurs_05_06 { get; set; }
        public string DecaissementPrestataires_05_06 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_05_06 { get; set; }
        public string DecaissementSalairesNets_05_06 { get; set; }
        public string CotisationsSociales_05_06 { get; set; }
        public string IRGSalaires_05_06 { get; set; }
        public string TVAPayer_05_06 { get; set; }
        public string IBS_IFU_05_06 { get; set; }
        public string TotalDepense_05_06 { get; set; }
        public string SoldeFinal_05_06 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année05 Mois07
        public string SoldeInitial_05_07 { get; set; }
        public string ApportSupplementaire_05_07 { get; set; }
        public string CMT_05_07 { get; set; }
        public string PNRClassique_05_07 { get; set; }
        public string ApportPersonnel_05_07 { get; set; }
        public string PNRLoyer_05_07 { get; set; }
        public string EncaissementRecusClients_05_07 { get; set; }
        public string TotalRecette_05_07 { get; set; }
        public string AcquisitionEquipementAmenagement_05_07 { get; set; }
        public string DecaissementFournisseurs_05_07 { get; set; }
        public string DecaissementPrestataires_05_07 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_05_07 { get; set; }
        public string DecaissementSalairesNets_05_07 { get; set; }
        public string CotisationsSociales_05_07 { get; set; }
        public string IRGSalaires_05_07 { get; set; }
        public string TVAPayer_05_07 { get; set; }
        public string IBS_IFU_05_07 { get; set; }
        public string TotalDepense_05_07 { get; set; }
        public string SoldeFinal_05_07 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année05 Mois08
        public string SoldeInitial_05_08 { get; set; }
        public string ApportSupplementaire_05_08 { get; set; }
        public string CMT_05_08 { get; set; }
        public string PNRClassique_05_08 { get; set; }
        public string ApportPersonnel_05_08 { get; set; }
        public string PNRLoyer_05_08 { get; set; }
        public string EncaissementRecusClients_05_08 { get; set; }
        public string TotalRecette_05_08 { get; set; }
        public string AcquisitionEquipementAmenagement_05_08 { get; set; }
        public string DecaissementFournisseurs_05_08 { get; set; }
        public string DecaissementPrestataires_05_08 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_05_08 { get; set; }
        public string DecaissementSalairesNets_05_08 { get; set; }
        public string CotisationsSociales_05_08 { get; set; }
        public string IRGSalaires_05_08 { get; set; }
        public string TVAPayer_05_08 { get; set; }
        public string IBS_IFU_05_08 { get; set; }
        public string TotalDepense_05_08 { get; set; }
        public string SoldeFinal_05_08 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année05 Mois09
        public string SoldeInitial_05_09 { get; set; }
        public string ApportSupplementaire_05_09 { get; set; }
        public string CMT_05_09 { get; set; }
        public string PNRClassique_05_09 { get; set; }
        public string ApportPersonnel_05_09 { get; set; }
        public string PNRLoyer_05_09 { get; set; }
        public string EncaissementRecusClients_05_09 { get; set; }
        public string TotalRecette_05_09 { get; set; }
        public string AcquisitionEquipementAmenagement_05_09 { get; set; }
        public string DecaissementFournisseurs_05_09 { get; set; }
        public string DecaissementPrestataires_05_09 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_05_09 { get; set; }
        public string DecaissementSalairesNets_05_09 { get; set; }
        public string CotisationsSociales_05_09 { get; set; }
        public string IRGSalaires_05_09 { get; set; }
        public string TVAPayer_05_09 { get; set; }
        public string IBS_IFU_05_09 { get; set; }
        public string TotalDepense_05_09 { get; set; }
        public string SoldeFinal_05_09 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année05 Mois10
        public string SoldeInitial_05_10 { get; set; }
        public string ApportSupplementaire_05_10 { get; set; }
        public string CMT_05_10 { get; set; }
        public string PNRClassique_05_10 { get; set; }
        public string ApportPersonnel_05_10 { get; set; }
        public string PNRLoyer_05_10 { get; set; }
        public string EncaissementRecusClients_05_10 { get; set; }
        public string TotalRecette_05_10 { get; set; }
        public string AcquisitionEquipementAmenagement_05_10 { get; set; }
        public string DecaissementFournisseurs_05_10 { get; set; }
        public string DecaissementPrestataires_05_10 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_05_10 { get; set; }
        public string DecaissementSalairesNets_05_10 { get; set; }
        public string CotisationsSociales_05_10 { get; set; }
        public string IRGSalaires_05_10 { get; set; }
        public string TVAPayer_05_10 { get; set; }
        public string IBS_IFU_05_10 { get; set; }
        public string TotalDepense_05_10 { get; set; }
        public string SoldeFinal_05_10 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année05 Mois11
        public string SoldeInitial_05_11 { get; set; }
        public string ApportSupplementaire_05_11 { get; set; }
        public string CMT_05_11 { get; set; }
        public string PNRClassique_05_11 { get; set; }
        public string ApportPersonnel_05_11 { get; set; }
        public string PNRLoyer_05_11 { get; set; }
        public string EncaissementRecusClients_05_11 { get; set; }
        public string TotalRecette_05_11 { get; set; }
        public string AcquisitionEquipementAmenagement_05_11 { get; set; }
        public string DecaissementFournisseurs_05_11 { get; set; }
        public string DecaissementPrestataires_05_11 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_05_11 { get; set; }
        public string DecaissementSalairesNets_05_11 { get; set; }
        public string CotisationsSociales_05_11 { get; set; }
        public string IRGSalaires_05_11 { get; set; }
        public string TVAPayer_05_11 { get; set; }
        public string IBS_IFU_05_11 { get; set; }
        public string TotalDepense_05_11 { get; set; }
        public string SoldeFinal_05_11 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année05 Mois12
        public string SoldeInitial_05_12 { get; set; }
        public string ApportSupplementaire_05_12 { get; set; }
        public string CMT_05_12 { get; set; }
        public string PNRClassique_05_12 { get; set; }
        public string ApportPersonnel_05_12 { get; set; }
        public string PNRLoyer_05_12 { get; set; }
        public string EncaissementRecusClients_05_12 { get; set; }
        public string TotalRecette_05_12 { get; set; }
        public string AcquisitionEquipementAmenagement_05_12 { get; set; }
        public string DecaissementFournisseurs_05_12 { get; set; }
        public string DecaissementPrestataires_05_12 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_05_12 { get; set; }
        public string DecaissementSalairesNets_05_12 { get; set; }
        public string CotisationsSociales_05_12 { get; set; }
        public string IRGSalaires_05_12 { get; set; }
        public string TVAPayer_05_12 { get; set; }
        public string IBS_IFU_05_12 { get; set; }
        public string TotalDepense_05_12 { get; set; }
        public string SoldeFinal_05_12 { get; set; }
        #endregion

        #endregion

        #region Données EtatPlanTresorerie Année06

        #region Données EtatPlanTresorerie Année06 Mois01
        public string SoldeInitial_06_01 { get; set; }
        public string ApportSupplementaire_06_01 { get; set; }
        public string CMT_06_01 { get; set; }
        public string PNRClassique_06_01 { get; set; }
        public string ApportPersonnel_06_01 { get; set; }
        public string PNRLoyer_06_01 { get; set; }
        public string EncaissementRecusClients_06_01 { get; set; }
        public string TotalRecette_06_01 { get; set; }
        public string AcquisitionEquipementAmenagement_06_01 { get; set; }
        public string DecaissementFournisseurs_06_01 { get; set; }
        public string DecaissementPrestataires_06_01 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_06_01 { get; set; }
        public string DecaissementSalairesNets_06_01 { get; set; }
        public string CotisationsSociales_06_01 { get; set; }
        public string IRGSalaires_06_01 { get; set; }
        public string TVAPayer_06_01 { get; set; }
        public string IBS_IFU_06_01 { get; set; }
        public string TotalDepense_06_01 { get; set; }
        public string SoldeFinal_06_01 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année06 Mois02
        public string SoldeInitial_06_02 { get; set; }
        public string ApportSupplementaire_06_02 { get; set; }
        public string CMT_06_02 { get; set; }
        public string PNRClassique_06_02 { get; set; }
        public string ApportPersonnel_06_02 { get; set; }
        public string PNRLoyer_06_02 { get; set; }
        public string EncaissementRecusClients_06_02 { get; set; }
        public string TotalRecette_06_02 { get; set; }
        public string AcquisitionEquipementAmenagement_06_02 { get; set; }
        public string DecaissementFournisseurs_06_02 { get; set; }
        public string DecaissementPrestataires_06_02 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_06_02 { get; set; }
        public string DecaissementSalairesNets_06_02 { get; set; }
        public string CotisationsSociales_06_02 { get; set; }
        public string IRGSalaires_06_02 { get; set; }
        public string TVAPayer_06_02 { get; set; }
        public string IBS_IFU_06_02 { get; set; }
        public string TotalDepense_06_02 { get; set; }
        public string SoldeFinal_06_02 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année06 Mois03
        public string SoldeInitial_06_03 { get; set; }
        public string ApportSupplementaire_06_03 { get; set; }
        public string CMT_06_03 { get; set; }
        public string PNRClassique_06_03 { get; set; }
        public string ApportPersonnel_06_03 { get; set; }
        public string PNRLoyer_06_03 { get; set; }
        public string EncaissementRecusClients_06_03 { get; set; }
        public string TotalRecette_06_03 { get; set; }
        public string AcquisitionEquipementAmenagement_06_03 { get; set; }
        public string DecaissementFournisseurs_06_03 { get; set; }
        public string DecaissementPrestataires_06_03 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_06_03 { get; set; }
        public string DecaissementSalairesNets_06_03 { get; set; }
        public string CotisationsSociales_06_03 { get; set; }
        public string IRGSalaires_06_03 { get; set; }
        public string TVAPayer_06_03 { get; set; }
        public string IBS_IFU_06_03 { get; set; }
        public string TotalDepense_06_03 { get; set; }
        public string SoldeFinal_06_03 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année06 Mois04
        public string SoldeInitial_06_04 { get; set; }
        public string ApportSupplementaire_06_04 { get; set; }
        public string CMT_06_04 { get; set; }
        public string PNRClassique_06_04 { get; set; }
        public string ApportPersonnel_06_04 { get; set; }
        public string PNRLoyer_06_04 { get; set; }
        public string EncaissementRecusClients_06_04 { get; set; }
        public string TotalRecette_06_04 { get; set; }
        public string AcquisitionEquipementAmenagement_06_04 { get; set; }
        public string DecaissementFournisseurs_06_04 { get; set; }
        public string DecaissementPrestataires_06_04 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_06_04 { get; set; }
        public string DecaissementSalairesNets_06_04 { get; set; }
        public string CotisationsSociales_06_04 { get; set; }
        public string IRGSalaires_06_04 { get; set; }
        public string TVAPayer_06_04 { get; set; }
        public string IBS_IFU_06_04 { get; set; }
        public string TotalDepense_06_04 { get; set; }
        public string SoldeFinal_06_04 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année06 Mois05
        public string SoldeInitial_06_05 { get; set; }
        public string ApportSupplementaire_06_05 { get; set; }
        public string CMT_06_05 { get; set; }
        public string PNRClassique_06_05 { get; set; }
        public string ApportPersonnel_06_05 { get; set; }
        public string PNRLoyer_06_05 { get; set; }
        public string EncaissementRecusClients_06_05 { get; set; }
        public string TotalRecette_06_05 { get; set; }
        public string AcquisitionEquipementAmenagement_06_05 { get; set; }
        public string DecaissementFournisseurs_06_05 { get; set; }
        public string DecaissementPrestataires_06_05 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_06_05 { get; set; }
        public string DecaissementSalairesNets_06_05 { get; set; }
        public string CotisationsSociales_06_05 { get; set; }
        public string IRGSalaires_06_05 { get; set; }
        public string TVAPayer_06_05 { get; set; }
        public string IBS_IFU_06_05 { get; set; }
        public string TotalDepense_06_05 { get; set; }
        public string SoldeFinal_06_05 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année06 Mois06
        public string SoldeInitial_06_06 { get; set; }
        public string ApportSupplementaire_06_06 { get; set; }
        public string CMT_06_06 { get; set; }
        public string PNRClassique_06_06 { get; set; }
        public string ApportPersonnel_06_06 { get; set; }
        public string PNRLoyer_06_06 { get; set; }
        public string EncaissementRecusClients_06_06 { get; set; }
        public string TotalRecette_06_06 { get; set; }
        public string AcquisitionEquipementAmenagement_06_06 { get; set; }
        public string DecaissementFournisseurs_06_06 { get; set; }
        public string DecaissementPrestataires_06_06 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_06_06 { get; set; }
        public string DecaissementSalairesNets_06_06 { get; set; }
        public string CotisationsSociales_06_06 { get; set; }
        public string IRGSalaires_06_06 { get; set; }
        public string TVAPayer_06_06 { get; set; }
        public string IBS_IFU_06_06 { get; set; }
        public string TotalDepense_06_06 { get; set; }
        public string SoldeFinal_06_06 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année06 Mois07
        public string SoldeInitial_06_07 { get; set; }
        public string ApportSupplementaire_06_07 { get; set; }
        public string CMT_06_07 { get; set; }
        public string PNRClassique_06_07 { get; set; }
        public string ApportPersonnel_06_07 { get; set; }
        public string PNRLoyer_06_07 { get; set; }
        public string EncaissementRecusClients_06_07 { get; set; }
        public string TotalRecette_06_07 { get; set; }
        public string AcquisitionEquipementAmenagement_06_07 { get; set; }
        public string DecaissementFournisseurs_06_07 { get; set; }
        public string DecaissementPrestataires_06_07 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_06_07 { get; set; }
        public string DecaissementSalairesNets_06_07 { get; set; }
        public string CotisationsSociales_06_07 { get; set; }
        public string IRGSalaires_06_07 { get; set; }
        public string TVAPayer_06_07 { get; set; }
        public string IBS_IFU_06_07 { get; set; }
        public string TotalDepense_06_07 { get; set; }
        public string SoldeFinal_06_07 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année06 Mois08
        public string SoldeInitial_06_08 { get; set; }
        public string ApportSupplementaire_06_08 { get; set; }
        public string CMT_06_08 { get; set; }
        public string PNRClassique_06_08 { get; set; }
        public string ApportPersonnel_06_08 { get; set; }
        public string PNRLoyer_06_08 { get; set; }
        public string EncaissementRecusClients_06_08 { get; set; }
        public string TotalRecette_06_08 { get; set; }
        public string AcquisitionEquipementAmenagement_06_08 { get; set; }
        public string DecaissementFournisseurs_06_08 { get; set; }
        public string DecaissementPrestataires_06_08 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_06_08 { get; set; }
        public string DecaissementSalairesNets_06_08 { get; set; }
        public string CotisationsSociales_06_08 { get; set; }
        public string IRGSalaires_06_08 { get; set; }
        public string TVAPayer_06_08 { get; set; }
        public string IBS_IFU_06_08 { get; set; }
        public string TotalDepense_06_08 { get; set; }
        public string SoldeFinal_06_08 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année06 Mois09
        public string SoldeInitial_06_09 { get; set; }
        public string ApportSupplementaire_06_09 { get; set; }
        public string CMT_06_09 { get; set; }
        public string PNRClassique_06_09 { get; set; }
        public string ApportPersonnel_06_09 { get; set; }
        public string PNRLoyer_06_09 { get; set; }
        public string EncaissementRecusClients_06_09 { get; set; }
        public string TotalRecette_06_09 { get; set; }
        public string AcquisitionEquipementAmenagement_06_09 { get; set; }
        public string DecaissementFournisseurs_06_09 { get; set; }
        public string DecaissementPrestataires_06_09 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_06_09 { get; set; }
        public string DecaissementSalairesNets_06_09 { get; set; }
        public string CotisationsSociales_06_09 { get; set; }
        public string IRGSalaires_06_09 { get; set; }
        public string TVAPayer_06_09 { get; set; }
        public string IBS_IFU_06_09 { get; set; }
        public string TotalDepense_06_09 { get; set; }
        public string SoldeFinal_06_09 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année06 Mois10
        public string SoldeInitial_06_10 { get; set; }
        public string ApportSupplementaire_06_10 { get; set; }
        public string CMT_06_10 { get; set; }
        public string PNRClassique_06_10 { get; set; }
        public string ApportPersonnel_06_10 { get; set; }
        public string PNRLoyer_06_10 { get; set; }
        public string EncaissementRecusClients_06_10 { get; set; }
        public string TotalRecette_06_10 { get; set; }
        public string AcquisitionEquipementAmenagement_06_10 { get; set; }
        public string DecaissementFournisseurs_06_10 { get; set; }
        public string DecaissementPrestataires_06_10 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_06_10 { get; set; }
        public string DecaissementSalairesNets_06_10 { get; set; }
        public string CotisationsSociales_06_10 { get; set; }
        public string IRGSalaires_06_10 { get; set; }
        public string TVAPayer_06_10 { get; set; }
        public string IBS_IFU_06_10 { get; set; }
        public string TotalDepense_06_10 { get; set; }
        public string SoldeFinal_06_10 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année06 Mois11
        public string SoldeInitial_06_11 { get; set; }
        public string ApportSupplementaire_06_11 { get; set; }
        public string CMT_06_11 { get; set; }
        public string PNRClassique_06_11 { get; set; }
        public string ApportPersonnel_06_11 { get; set; }
        public string PNRLoyer_06_11 { get; set; }
        public string EncaissementRecusClients_06_11 { get; set; }
        public string TotalRecette_06_11 { get; set; }
        public string AcquisitionEquipementAmenagement_06_11 { get; set; }
        public string DecaissementFournisseurs_06_11 { get; set; }
        public string DecaissementPrestataires_06_11 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_06_11 { get; set; }
        public string DecaissementSalairesNets_06_11 { get; set; }
        public string CotisationsSociales_06_11 { get; set; }
        public string IRGSalaires_06_11 { get; set; }
        public string TVAPayer_06_11 { get; set; }
        public string IBS_IFU_06_11 { get; set; }
        public string TotalDepense_06_11 { get; set; }
        public string SoldeFinal_06_11 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année06 Mois12
        public string SoldeInitial_06_12 { get; set; }
        public string ApportSupplementaire_06_12 { get; set; }
        public string CMT_06_12 { get; set; }
        public string PNRClassique_06_12 { get; set; }
        public string ApportPersonnel_06_12 { get; set; }
        public string PNRLoyer_06_12 { get; set; }
        public string EncaissementRecusClients_06_12 { get; set; }
        public string TotalRecette_06_12 { get; set; }
        public string AcquisitionEquipementAmenagement_06_12 { get; set; }
        public string DecaissementFournisseurs_06_12 { get; set; }
        public string DecaissementPrestataires_06_12 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_06_12 { get; set; }
        public string DecaissementSalairesNets_06_12 { get; set; }
        public string CotisationsSociales_06_12 { get; set; }
        public string IRGSalaires_06_12 { get; set; }
        public string TVAPayer_06_12 { get; set; }
        public string IBS_IFU_06_12 { get; set; }
        public string TotalDepense_06_12 { get; set; }
        public string SoldeFinal_06_12 { get; set; }
        #endregion

        #endregion

        #region Données EtatPlanTresorerie Année07

        #region Données EtatPlanTresorerie Année07 Mois01
        public string SoldeInitial_07_01 { get; set; }
        public string ApportSupplementaire_07_01 { get; set; }
        public string CMT_07_01 { get; set; }
        public string PNRClassique_07_01 { get; set; }
        public string ApportPersonnel_07_01 { get; set; }
        public string PNRLoyer_07_01 { get; set; }
        public string EncaissementRecusClients_07_01 { get; set; }
        public string TotalRecette_07_01 { get; set; }
        public string AcquisitionEquipementAmenagement_07_01 { get; set; }
        public string DecaissementFournisseurs_07_01 { get; set; }
        public string DecaissementPrestataires_07_01 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_07_01 { get; set; }
        public string DecaissementSalairesNets_07_01 { get; set; }
        public string CotisationsSociales_07_01 { get; set; }
        public string IRGSalaires_07_01 { get; set; }
        public string TVAPayer_07_01 { get; set; }
        public string IBS_IFU_07_01 { get; set; }
        public string TotalDepense_07_01 { get; set; }
        public string SoldeFinal_07_01 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année07 Mois02
        public string SoldeInitial_07_02 { get; set; }
        public string ApportSupplementaire_07_02 { get; set; }
        public string CMT_07_02 { get; set; }
        public string PNRClassique_07_02 { get; set; }
        public string ApportPersonnel_07_02 { get; set; }
        public string PNRLoyer_07_02 { get; set; }
        public string EncaissementRecusClients_07_02 { get; set; }
        public string TotalRecette_07_02 { get; set; }
        public string AcquisitionEquipementAmenagement_07_02 { get; set; }
        public string DecaissementFournisseurs_07_02 { get; set; }
        public string DecaissementPrestataires_07_02 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_07_02 { get; set; }
        public string DecaissementSalairesNets_07_02 { get; set; }
        public string CotisationsSociales_07_02 { get; set; }
        public string IRGSalaires_07_02 { get; set; }
        public string TVAPayer_07_02 { get; set; }
        public string IBS_IFU_07_02 { get; set; }
        public string TotalDepense_07_02 { get; set; }
        public string SoldeFinal_07_02 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année07 Mois03
        public string SoldeInitial_07_03 { get; set; }
        public string ApportSupplementaire_07_03 { get; set; }
        public string CMT_07_03 { get; set; }
        public string PNRClassique_07_03 { get; set; }
        public string ApportPersonnel_07_03 { get; set; }
        public string PNRLoyer_07_03 { get; set; }
        public string EncaissementRecusClients_07_03 { get; set; }
        public string TotalRecette_07_03 { get; set; }
        public string AcquisitionEquipementAmenagement_07_03 { get; set; }
        public string DecaissementFournisseurs_07_03 { get; set; }
        public string DecaissementPrestataires_07_03 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_07_03 { get; set; }
        public string DecaissementSalairesNets_07_03 { get; set; }
        public string CotisationsSociales_07_03 { get; set; }
        public string IRGSalaires_07_03 { get; set; }
        public string TVAPayer_07_03 { get; set; }
        public string IBS_IFU_07_03 { get; set; }
        public string TotalDepense_07_03 { get; set; }
        public string SoldeFinal_07_03 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année07 Mois04
        public string SoldeInitial_07_04 { get; set; }
        public string ApportSupplementaire_07_04 { get; set; }
        public string CMT_07_04 { get; set; }
        public string PNRClassique_07_04 { get; set; }
        public string ApportPersonnel_07_04 { get; set; }
        public string PNRLoyer_07_04 { get; set; }
        public string EncaissementRecusClients_07_04 { get; set; }
        public string TotalRecette_07_04 { get; set; }
        public string AcquisitionEquipementAmenagement_07_04 { get; set; }
        public string DecaissementFournisseurs_07_04 { get; set; }
        public string DecaissementPrestataires_07_04 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_07_04 { get; set; }
        public string DecaissementSalairesNets_07_04 { get; set; }
        public string CotisationsSociales_07_04 { get; set; }
        public string IRGSalaires_07_04 { get; set; }
        public string TVAPayer_07_04 { get; set; }
        public string IBS_IFU_07_04 { get; set; }
        public string TotalDepense_07_04 { get; set; }
        public string SoldeFinal_07_04 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année07 Mois05
        public string SoldeInitial_07_05 { get; set; }
        public string ApportSupplementaire_07_05 { get; set; }
        public string CMT_07_05 { get; set; }
        public string PNRClassique_07_05 { get; set; }
        public string ApportPersonnel_07_05 { get; set; }
        public string PNRLoyer_07_05 { get; set; }
        public string EncaissementRecusClients_07_05 { get; set; }
        public string TotalRecette_07_05 { get; set; }
        public string AcquisitionEquipementAmenagement_07_05 { get; set; }
        public string DecaissementFournisseurs_07_05 { get; set; }
        public string DecaissementPrestataires_07_05 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_07_05 { get; set; }
        public string DecaissementSalairesNets_07_05 { get; set; }
        public string CotisationsSociales_07_05 { get; set; }
        public string IRGSalaires_07_05 { get; set; }
        public string TVAPayer_07_05 { get; set; }
        public string IBS_IFU_07_05 { get; set; }
        public string TotalDepense_07_05 { get; set; }
        public string SoldeFinal_07_05 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année07 Mois06
        public string SoldeInitial_07_06 { get; set; }
        public string ApportSupplementaire_07_06 { get; set; }
        public string CMT_07_06 { get; set; }
        public string PNRClassique_07_06 { get; set; }
        public string ApportPersonnel_07_06 { get; set; }
        public string PNRLoyer_07_06 { get; set; }
        public string EncaissementRecusClients_07_06 { get; set; }
        public string TotalRecette_07_06 { get; set; }
        public string AcquisitionEquipementAmenagement_07_06 { get; set; }
        public string DecaissementFournisseurs_07_06 { get; set; }
        public string DecaissementPrestataires_07_06 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_07_06 { get; set; }
        public string DecaissementSalairesNets_07_06 { get; set; }
        public string CotisationsSociales_07_06 { get; set; }
        public string IRGSalaires_07_06 { get; set; }
        public string TVAPayer_07_06 { get; set; }
        public string IBS_IFU_07_06 { get; set; }
        public string TotalDepense_07_06 { get; set; }
        public string SoldeFinal_07_06 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année07 Mois07
        public string SoldeInitial_07_07 { get; set; }
        public string ApportSupplementaire_07_07 { get; set; }
        public string CMT_07_07 { get; set; }
        public string PNRClassique_07_07 { get; set; }
        public string ApportPersonnel_07_07 { get; set; }
        public string PNRLoyer_07_07 { get; set; }
        public string EncaissementRecusClients_07_07 { get; set; }
        public string TotalRecette_07_07 { get; set; }
        public string AcquisitionEquipementAmenagement_07_07 { get; set; }
        public string DecaissementFournisseurs_07_07 { get; set; }
        public string DecaissementPrestataires_07_07 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_07_07 { get; set; }
        public string DecaissementSalairesNets_07_07 { get; set; }
        public string CotisationsSociales_07_07 { get; set; }
        public string IRGSalaires_07_07 { get; set; }
        public string TVAPayer_07_07 { get; set; }
        public string IBS_IFU_07_07 { get; set; }
        public string TotalDepense_07_07 { get; set; }
        public string SoldeFinal_07_07 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année07 Mois08
        public string SoldeInitial_07_08 { get; set; }
        public string ApportSupplementaire_07_08 { get; set; }
        public string CMT_07_08 { get; set; }
        public string PNRClassique_07_08 { get; set; }
        public string ApportPersonnel_07_08 { get; set; }
        public string PNRLoyer_07_08 { get; set; }
        public string EncaissementRecusClients_07_08 { get; set; }
        public string TotalRecette_07_08 { get; set; }
        public string AcquisitionEquipementAmenagement_07_08 { get; set; }
        public string DecaissementFournisseurs_07_08 { get; set; }
        public string DecaissementPrestataires_07_08 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_07_08 { get; set; }
        public string DecaissementSalairesNets_07_08 { get; set; }
        public string CotisationsSociales_07_08 { get; set; }
        public string IRGSalaires_07_08 { get; set; }
        public string TVAPayer_07_08 { get; set; }
        public string IBS_IFU_07_08 { get; set; }
        public string TotalDepense_07_08 { get; set; }
        public string SoldeFinal_07_08 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année07 Mois09
        public string SoldeInitial_07_09 { get; set; }
        public string ApportSupplementaire_07_09 { get; set; }
        public string CMT_07_09 { get; set; }
        public string PNRClassique_07_09 { get; set; }
        public string ApportPersonnel_07_09 { get; set; }
        public string PNRLoyer_07_09 { get; set; }
        public string EncaissementRecusClients_07_09 { get; set; }
        public string TotalRecette_07_09 { get; set; }
        public string AcquisitionEquipementAmenagement_07_09 { get; set; }
        public string DecaissementFournisseurs_07_09 { get; set; }
        public string DecaissementPrestataires_07_09 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_07_09 { get; set; }
        public string DecaissementSalairesNets_07_09 { get; set; }
        public string CotisationsSociales_07_09 { get; set; }
        public string IRGSalaires_07_09 { get; set; }
        public string TVAPayer_07_09 { get; set; }
        public string IBS_IFU_07_09 { get; set; }
        public string TotalDepense_07_09 { get; set; }
        public string SoldeFinal_07_09 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année07 Mois10
        public string SoldeInitial_07_10 { get; set; }
        public string ApportSupplementaire_07_10 { get; set; }
        public string CMT_07_10 { get; set; }
        public string PNRClassique_07_10 { get; set; }
        public string ApportPersonnel_07_10 { get; set; }
        public string PNRLoyer_07_10 { get; set; }
        public string EncaissementRecusClients_07_10 { get; set; }
        public string TotalRecette_07_10 { get; set; }
        public string AcquisitionEquipementAmenagement_07_10 { get; set; }
        public string DecaissementFournisseurs_07_10 { get; set; }
        public string DecaissementPrestataires_07_10 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_07_10 { get; set; }
        public string DecaissementSalairesNets_07_10 { get; set; }
        public string CotisationsSociales_07_10 { get; set; }
        public string IRGSalaires_07_10 { get; set; }
        public string TVAPayer_07_10 { get; set; }
        public string IBS_IFU_07_10 { get; set; }
        public string TotalDepense_07_10 { get; set; }
        public string SoldeFinal_07_10 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année07 Mois11
        public string SoldeInitial_07_11 { get; set; }
        public string ApportSupplementaire_07_11 { get; set; }
        public string CMT_07_11 { get; set; }
        public string PNRClassique_07_11 { get; set; }
        public string ApportPersonnel_07_11 { get; set; }
        public string PNRLoyer_07_11 { get; set; }
        public string EncaissementRecusClients_07_11 { get; set; }
        public string TotalRecette_07_11 { get; set; }
        public string AcquisitionEquipementAmenagement_07_11 { get; set; }
        public string DecaissementFournisseurs_07_11 { get; set; }
        public string DecaissementPrestataires_07_11 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_07_11 { get; set; }
        public string DecaissementSalairesNets_07_11 { get; set; }
        public string CotisationsSociales_07_11 { get; set; }
        public string IRGSalaires_07_11 { get; set; }
        public string TVAPayer_07_11 { get; set; }
        public string IBS_IFU_07_11 { get; set; }
        public string TotalDepense_07_11 { get; set; }
        public string SoldeFinal_07_11 { get; set; }
        #endregion

        #region Données EtatPlanTresorerie Année07 Mois12
        public string SoldeInitial_07_12 { get; set; }
        public string ApportSupplementaire_07_12 { get; set; }
        public string CMT_07_12 { get; set; }
        public string PNRClassique_07_12 { get; set; }
        public string ApportPersonnel_07_12 { get; set; }
        public string PNRLoyer_07_12 { get; set; }
        public string EncaissementRecusClients_07_12 { get; set; }
        public string TotalRecette_07_12 { get; set; }
        public string AcquisitionEquipementAmenagement_07_12 { get; set; }
        public string DecaissementFournisseurs_07_12 { get; set; }
        public string DecaissementPrestataires_07_12 { get; set; }
        public string PaiementFGAssurancesFraisLieesCreation_07_12 { get; set; }
        public string DecaissementSalairesNets_07_12 { get; set; }
        public string CotisationsSociales_07_12 { get; set; }
        public string IRGSalaires_07_12 { get; set; }
        public string TVAPayer_07_12 { get; set; }
        public string IBS_IFU_07_12 { get; set; }
        public string TotalDepense_07_12 { get; set; }
        public string SoldeFinal_07_12 { get; set; }
        #endregion

        #endregion

        /// <summary>
        /// Adds two integers and returns the result.
        /// </summary>
        /// <returns>
        /// The sum of two integers.
        /// </returns>
        /// <param name="left">
        /// The left operand of the addition.
        /// </param>
        /// <param name="right">
        /// The right operand of the addition.
        /// </param>
        /// <example>
        /// <code>
        /// int c = Math.Add(4, 5);
        /// if (c > 10)
        /// {
        ///     Console.WriteLine(c);
        /// }
        /// </code>
        /// </example>
        /// <exception cref="System.OverflowException">
        /// Thrown when one parameter is
        /// <see cref="Int32.MaxValue">MaxValue</see> and the other is
        /// greater than 0.
        /// Note that here you can also use
        /// <see href="https://learn.microsoft.com/dotnet/api/system.int32.maxvalue"/>
        ///  to point a web page instead.
        /// </exception>
        /// <see cref="ExampleClass"/> for a list of all
        /// the tags in these examples.
        /// <seealso cref="ExampleClass.Label"/>

    }
}
