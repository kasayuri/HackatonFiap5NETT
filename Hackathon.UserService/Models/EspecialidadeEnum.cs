using System.Runtime.Serialization;

namespace Hackathon.UserService.Models;

/// <summary>
/// Especialidades médicas reconhecidas oficialmente no Brasil
/// </summary>
public enum EspecialidadeEnum
{
    [EnumMember(Value = "Alergia e Imunologia")]
    AlergiaImunologia,

    [EnumMember(Value = "Anestesiologia")]
    Anestesiologia,

    [EnumMember(Value = "Angiologia")]
    Angiologia,

    [EnumMember(Value = "Cancerologia (Oncologia)")]
    Cancerologia,

    [EnumMember(Value = "Cardiologia")]
    Cardiologia,

    [EnumMember(Value = "Cirurgia Cardiovascular")]
    CirurgiaCardiovascular,

    [EnumMember(Value = "Cirurgia da Mão")]
    CirurgiaDaMao,

    [EnumMember(Value = "Cirurgia de Cabeça e Pescoço")]
    CirurgiaCabecaPescoco,

    [EnumMember(Value = "Cirurgia do Aparelho Digestivo")]
    CirurgiaAparelhoDigestivo,

    [EnumMember(Value = "Cirurgia Geral")]
    CirurgiaGeral,

    [EnumMember(Value = "Cirurgia Pediátrica")]
    CirurgiaPediatrica,

    [EnumMember(Value = "Cirurgia Plástica")]
    CirurgiaPlastica,

    [EnumMember(Value = "Cirurgia Torácica")]
    CirurgiaToracica,

    [EnumMember(Value = "Cirurgia Vascular")]
    CirurgiaVascular,

    [EnumMember(Value = "Clínica Médica")]
    ClinicaMedica,

    [EnumMember(Value = "Coloproctologia")]
    Coloproctologia,

    [EnumMember(Value = "Dermatologia")]
    Dermatologia,

    [EnumMember(Value = "Endocrinologia e Metabologia")]
    EndocrinologiaMetabologia,

    [EnumMember(Value = "Endoscopia")]
    Endoscopia,

    [EnumMember(Value = "Gastroenterologia")]
    Gastroenterologia,

    [EnumMember(Value = "Genética Médica")]
    GeneticaMedica,

    [EnumMember(Value = "Geriatria")]
    Geriatria,

    [EnumMember(Value = "Ginecologia e Obstetrícia")]
    GinecologiaObstetricia,

    [EnumMember(Value = "Hematologia e Hemoterapia")]
    HematologiaHemoterapia,

    [EnumMember(Value = "Homeopatia")]
    Homeopatia,

    [EnumMember(Value = "Infectologia")]
    Infectologia,

    [EnumMember(Value = "Mastologia")]
    Mastologia,

    [EnumMember(Value = "Medicina de Emergência")]
    MedicinaEmergencia,

    [EnumMember(Value = "Medicina de Família e Comunidade")]
    MedicinaFamiliaComunidade,

    [EnumMember(Value = "Medicina do Trabalho")]
    MedicinaTrabalho,

    [EnumMember(Value = "Medicina do Tráfego")]
    MedicinaTrafego,

    [EnumMember(Value = "Medicina Esportiva")]
    MedicinaEsportiva,

    [EnumMember(Value = "Medicina Física e Reabilitação")]
    MedicinaFisicaReabilitacao,

    [EnumMember(Value = "Medicina Intensiva")]
    MedicinaIntensiva,

    [EnumMember(Value = "Medicina Legal e Perícia Médica")]
    MedicinaLegalPericia,

    [EnumMember(Value = "Medicina Nuclear")]
    MedicinaNuclear,

    [EnumMember(Value = "Medicina Preventiva e Social")]
    MedicinaPreventivaSocial,

    [EnumMember(Value = "Nefrologia")]
    Nefrologia,

    [EnumMember(Value = "Neurocirurgia")]
    Neurocirurgia,

    [EnumMember(Value = "Neurologia")]
    Neurologia,

    [EnumMember(Value = "Nutrologia")]
    Nutrologia,

    [EnumMember(Value = "Oftalmologia")]
    Oftalmologia,

    [EnumMember(Value = "Oncologia Clínica")]
    OncologiaClinica,

    [EnumMember(Value = "Ortopedia e Traumatologia")]
    OrtopediaTraumatologia,

    [EnumMember(Value = "Otorrinolaringologia")]
    Otorrinolaringologia,

    [EnumMember(Value = "Patologia")]
    Patologia,

    [EnumMember(Value = "Patologia Clínica / Medicina Laboratorial")]
    PatologiaClinica,

    [EnumMember(Value = "Pediatria")]
    Pediatria,

    [EnumMember(Value = "Pneumologia")]
    Pneumologia,

    [EnumMember(Value = "Psiquiatria")]
    Psiquiatria,

    [EnumMember(Value = "Radiologia e Diagnóstico por Imagem")]
    RadiologiaDiagnostico,

    [EnumMember(Value = "Radioterapia")]
    Radioterapia,

    [EnumMember(Value = "Reumatologia")]
    Reumatologia,

    [EnumMember(Value = "Urologia")]
    Urologia,

    [EnumMember(Value = "Medicina de Dor")]
    MedicinaDor
}