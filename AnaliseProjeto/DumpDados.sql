-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: maisservicos
-- ------------------------------------------------------
-- Server version	8.0.34

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `areadeatuacao`
--

LOCK TABLES `areadeatuacao` WRITE;
/*!40000 ALTER TABLE `areadeatuacao` DISABLE KEYS */;
INSERT INTO `areadeatuacao` VALUES (1,'Construcao Civil'),(2,'Eletricista'),(3,'Gesseiro');
/*!40000 ALTER TABLE `areadeatuacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
INSERT INTO `aspnetroles` VALUES ('1','Cliente','cliente',NULL),('2','Prestador','prestador',NULL),('3','Administrador','admin',NULL);
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `aspnetusers_has_pessoa`
--

LOCK TABLES `aspnetusers_has_pessoa` WRITE;
/*!40000 ALTER TABLE `aspnetusers_has_pessoa` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusers_has_pessoa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `avaliacao`
--

LOCK TABLES `avaliacao` WRITE;
/*!40000 ALTER TABLE `avaliacao` DISABLE KEYS */;
INSERT INTO `avaliacao` VALUES (1,'2020-10-10 00:00:00','5','Otimo servico, profissional muito atencioso',1),(2,'2022-11-07 00:00:00','3','O servico foi bem executado, mas demorou muito para ser concluido',2),(3,'2023-04-24 00:00:00','4','Gostei',3);
/*!40000 ALTER TABLE `avaliacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `orcamento`
--

LOCK TABLES `orcamento` WRITE;
/*!40000 ALTER TABLE `orcamento` DISABLE KEYS */;
INSERT INTO `orcamento` VALUES (1,200,'fiancao eletrica','2023-03-27 00:00:00',1),(2,300,'Revestimento da parede da cozinha','2022-09-12 00:00:00',2),(3,100,'resistencia do chuveiro','2020-10-10 00:00:00',3);
/*!40000 ALTER TABLE `orcamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `pessoa`
--

LOCK TABLES `pessoa` WRITE;
/*!40000 ALTER TABLE `pessoa` DISABLE KEYS */;
INSERT INTO `pessoa` VALUES (1,'Cassio Ramos','paredaocassio@gmail.com','12345678911','79999873254','49500000','se','itabaiana','um bairro','umarua','12','cliente'),(2,'Yuri Alberto','bagrealberto@gmail.com','09876543217','79998765432','49599001','ba','salvador','sei la','qualquer uma ai','09','cliente'),(3,'Renato Algusto','reinatoA08@gmail.com','87654329875','13999767856','34567656','sp','sao paulo','itaquera','meiuca','08','prestador'),(4,'Fabio Santos','tiochico@gmail.com','74653876298','13998762917','45362777','sp','santos','baixada santista','avenida Fabio Santos','06','prestador');
/*!40000 ALTER TABLE `pessoa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `servico`
--

LOCK TABLES `servico` WRITE;
/*!40000 ALTER TABLE `servico` DISABLE KEYS */;
INSERT INTO `servico` VALUES (1,'Forro liso','forro de gesso sem decoracoes',3),(2,'Insalacao geral','preparar toda a parte eletrica da casa',2),(3,'Rebocar paredes','fazer o acabamento das paredes com cimento',1);
/*!40000 ALTER TABLE `servico` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `servicocontratado`
--

LOCK TABLES `servicocontratado` WRITE;
/*!40000 ALTER TABLE `servicocontratado` DISABLE KEYS */;
INSERT INTO `servicocontratado` VALUES (1,200,1,1,1,1),(2,300,2,2,1,2),(3,100,3,3,1,3);
/*!40000 ALTER TABLE `servicocontratado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `servicoservicocontratado`
--

LOCK TABLES `servicoservicocontratado` WRITE;
/*!40000 ALTER TABLE `servicoservicocontratado` DISABLE KEYS */;
INSERT INTO `servicoservicocontratado` VALUES (1,1,1),(2,2,2),(3,3,3);
/*!40000 ALTER TABLE `servicoservicocontratado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `solicitarorcamento`
--

LOCK TABLES `solicitarorcamento` WRITE;
/*!40000 ALTER TABLE `solicitarorcamento` DISABLE KEYS */;
INSERT INTO `solicitarorcamento` VALUES (1,'trocar lampada','2020-10-23 00:00:00',1),(2,'colocar piso no chao da casa','2022-11-13 00:00:00',2),(3,'Fazer o forro do quarto em gesso','2023-07-12 00:00:00',3);
/*!40000 ALTER TABLE `solicitarorcamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `templatecontrato`
--

LOCK TABLES `templatecontrato` WRITE;
/*!40000 ALTER TABLE `templatecontrato` DISABLE KEYS */;
INSERT INTO `templatecontrato` VALUES (1,_binary 'CONTRATO DE PRESTA\Ç\ÃO DE SERVI\ÇOS\n\nEntre:\n\n___________________, solteiro, nacionalidade: ___________________, profiss\ão: ___________________, carteira de identidade (RG) n.º ___________________, expedida por ___________, CPF n.º ___________________, residente em: ___________________,\n\ndoravante denominado CONTRATANTE,\n\ne:\n\na pessoa jur\ídica ___________________, inscrita sob o CNPJ n.º ___________________, com sede em ___________________\n\nneste ato representada, conforme poderes especialmente conferidos, por:\n\n___________________, na qualidade de: ___________________, CPF n.º ___________________, n.º ___________________, expedida por ___________________\n\ndoravante denominada CONTRATADA.\n\nAs partes acima identificadas t\êm, entre si, justo e acertado, o presente contrato de presta\ç\ão de servi\ços, ficando desde j\á aceito, pelas cl\áusulas abaixo descritas.\n\nCLÁUSULA 1ª - DO OBJETO\n\nPor meio deste contrato, a CONTRATADA se compromete a prestar ao CONTRATANTE os seguintes servi\ços:\n\n___________________\n\n§ 1º. A CONTRATADA prestar\á os servi\ços descritos nesta cl\áusula sem qualquer exclusividade, podendo desempenhar atividades para terceiros, desde que n\ão haja conflito de interesses com o pactuado no presente contrato.\n\n§ 2º. Os servi\ços descritos acima ser\ão prestados com total autonomia, sem pessoalidade e sem qualquer subordina\ç\ão ao CONTRATANTE.\n\nCLÁUSULA 2ª - DO PRAZO\n\nOs servi\ços ora contratados ser\ão prestados pelo prazo de ___________________, com in\ício em ___________________.\n\n§ 1º. Ao final do prazo acima referido, poder\á o contrato ser renovado em mútuo acordo, devendo constar em termo aditivo o novo prazo acordado.\n\n§ 2º. Caso n\ão ocorra a renova\ç\ão pelas partes no final do prazo acima referido, este contrato ser\á automaticamente rescindido sem que haja a necessidade de aviso pr\évio.\n\nCLÁUSULA 3ª - DA RETRIBUI\Ç\ÃO\n\nPela presta\ç\ão dos servi\ços o CONTRATANTE pagar\á \à CONTRATADA a quantia de R$ 0,00 (zero reais), que ser\á paga da seguinte maneira:\n\n___________________\n\n§ 1º. Dever\á o pagamento acordado neste instrumento ser efetuado por meio de transfer\ência banc\ária por pix utilizando a chave __________________.\n\n§ 2º. O CONTRATANTE n\ão vindo a efetuar o pagamento, fica obrigado a pagar multa de 0% (zero por cento) sobre o valor devido, bem como juros de mora de 1% (um por cento) ao m\ês, mais corre\ç\ão monet\ária apurada conforme varia\ç\ão do IGP-M no per\íodo.\n\nCLÁUSULA 4ª - DAS OBRIGA\Ç\ÕES DA CONTRATADA\n\nSem preju\ízo de outras disposi\ções deste contrato, constituem obriga\ções da CONTRATADA:\n\nI. prestar os servi\ços contratados na forma e modo ajustados, dentro das normas, dando plena e total garantia dos mesmos;\n\nII. executar os servi\ços contratados utilizando a melhor did\ática e aplicabilidade, visando sempre atingir o melhor resultado, sob sua exclusiva responsabilidade, sendo-lhe vedada a transfer\ência dos mesmos a terceiros, sem pr\évia e expressa concord\ância do CONTRATANTE;\n\nIII. ser respons\ável pelos atos praticados por seus respons\áveis, bem como pelos danos que os mesmos venham a causar para o CONTRATANTE, desde que comprovados, em decorr\ência da presta\ç\ão dos servi\ços prestados neste contrato;\n\nIV. cumprir todas as determina\ções impostas pelas autoridades públicas competentes;\n\nV. arcar devidamente, nos termos da legisla\ç\ão trabalhista, com a remunera\ç\ão e demais verbas laborais devidas a seus subordinados, inclusive encargos fiscais e previdenci\ários referentes \às rela\ções de trabalho;\n\nVI. arcar com todas as despesas de natureza tribut\ária decorrentes dos servi\ços especificados neste contrato;\n\nVII. fornecer os equipamentos necess\ários \à presta\ç\ão dos servi\ços.\n\nCLÁUSULA 5ª - DAS OBRIGA\Ç\ÕES DO CONTRATANTE\n\nSem preju\ízo de outras disposi\ções deste contrato, constituem obriga\ções do CONTRATANTE:\n\nI. fornecer \à CONTRATADA todas as informa\ções necess\árias \à realiza\ç\ão do servi\ço, devendo especificar os detalhes necess\ários \à perfeita execu\ç\ão do mesmo, e a forma de como ele deve ser entregue;\n\nII. efetuar o pagamento, nas datas e nos termos definidos neste contrato.\n\nCLÁUSULA 6ª - DA RESCIS\ÃO\n\nO presente instrumento poder\á ser rescindido caso qualquer uma das partes descumpra o disposto neste contrato.\n\n§ 1º. Na hipótese do CONTRATANTE solicitar a rescis\ão antecipada deste contrato sem justa causa, ser\á obrigado a pagar \à CONTRATADA por inteiro qualquer retribui\ç\ão vencida e n\ão paga, e metade do que ela receberia at\é o final do contrato.\n\n§ 2º. Na hipótese da CONTRATADA solicitar a rescis\ão antecipada deste contrato sem justa causa, esta ter\á direito \à retribui\ç\ão vencida, mas responder\á por perdas e danos que cause ao CONTRATANTE.\n\n§ 3º. A rescis\ão com justa causa por parte do CONTRATANTE obriga a devolu\ç\ão pela CONTRATADA de quaisquer valores j\á pagos referentes a servi\ços n\ão desenvolvidos.\n\nCLÁUSULA 7ª - DA EXTIN\Ç\ÃO DO CONTRATO\n\nO presente contrato extingue-se sem que assista \às partes direito a qualquer tipo de indeniza\ç\ão, ressarcimento ou multa, por mais especial que seja, nas seguintes hipóteses:\n\nI. por insolv\ência, impetra\ç\ão ou solicita\ç\ão de concordata, ou fal\ência, de qualquer uma das partes;\n\nII. por qualquer impossibilidade da continua\ç\ão do contrato, motivada por for\ça maior ou caso fortuito.\n\nCLÁUSULA 8ª - DAS CONDI\Ç\ÕES GERAIS\n\nSalvo expressa autoriza\ç\ão do CONTRATANTE, n\ão poder\á a CONTRATADA transferir ou subcontratar os servi\ços previstos neste instrumento, sob o risco de ocorrer a rescis\ão imediata.\n\n§ 1º. Qualquer condescend\ência entre as partes quanto ao cumprimento de qualquer cl\áusula do presente contrato, constituir\á mera toler\ância e n\ão importar\á em altera\ç\ão ou modifica\ç\ão das cl\áusulas contratuais.\n\n§ 2º. Qualquer servi\ço adicional, desde que acordado entre as partes, ser\á objeto de termo aditivo ao instrumento original.\n\nCLÁUSULA 9ª - DO FORO\n\nFica desde j\á eleito o foro da comarca de __________________ para serem resolvidas eventuais pend\ências decorrentes deste contrato.\n\nPor estarem assim certos e ajustados, firmam os signat\ários este instrumento em 02 (duas) vias de igual teor e forma.\n\n__________________, __/__/____.\n\n___________________________________\n\nCONTRATANTE: ___________________\n\n___________________________________\n\nCONTRATADA: ___________________\n\nneste ato representando a pessoa jur\ídica ___________________\n\n----------------------------------------------\n\nRefer\ência:\n\nLei 10.406\n\n----------------------------------------------\n\nIMPORTANTE:\nEste \é um modelo padr\ão b\ásico.\n\nCaso deseje personalizar o seu contrato, escolhendo outras op\ções, como, por exemplo, se o pagamento ser\á efetuado em parcelas, se ter\á multa por descumprimento, dentre diversas outras personaliza\ções, acesse o nosso modelo:\n\nhttps://www.99contratos.com.br/contrato-prestacao-servico-pf.php\n\nAo utilizar o nosso modelo personaliz\ável voc\ê poder\á elaborar e moldar o seu contrato de acordo com as suas respostas.\n\n');
/*!40000 ALTER TABLE `templatecontrato` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-10-20 21:23:08
