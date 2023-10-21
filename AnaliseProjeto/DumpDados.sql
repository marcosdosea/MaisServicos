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
INSERT INTO `templatecontrato` VALUES (1,_binary 'CONTRATO DE PRESTA\�\�O DE SERVI\�OS\n\nEntre:\n\n___________________, solteiro, nacionalidade: ___________________, profiss\�o: ___________________, carteira de identidade (RG) n.� ___________________, expedida por ___________, CPF n.� ___________________, residente em: ___________________,\n\ndoravante denominado CONTRATANTE,\n\ne:\n\na pessoa jur\�dica ___________________, inscrita sob o CNPJ n.� ___________________, com sede em ___________________\n\nneste ato representada, conforme poderes especialmente conferidos, por:\n\n___________________, na qualidade de: ___________________, CPF n.� ___________________, n.� ___________________, expedida por ___________________\n\ndoravante denominada CONTRATADA.\n\nAs partes acima identificadas t\�m, entre si, justo e acertado, o presente contrato de presta\�\�o de servi\�os, ficando desde j\� aceito, pelas cl\�usulas abaixo descritas.\n\nCL�USULA 1� - DO OBJETO\n\nPor meio deste contrato, a CONTRATADA se compromete a prestar ao CONTRATANTE os seguintes servi\�os:\n\n___________________\n\n� 1�. A CONTRATADA prestar\� os servi\�os descritos nesta cl\�usula sem qualquer exclusividade, podendo desempenhar atividades para terceiros, desde que n\�o haja conflito de interesses com o pactuado no presente contrato.\n\n� 2�. Os servi\�os descritos acima ser\�o prestados com total autonomia, sem pessoalidade e sem qualquer subordina\�\�o ao CONTRATANTE.\n\nCL�USULA 2� - DO PRAZO\n\nOs servi\�os ora contratados ser\�o prestados pelo prazo de ___________________, com in\�cio em ___________________.\n\n� 1�. Ao final do prazo acima referido, poder\� o contrato ser renovado em m�tuo acordo, devendo constar em termo aditivo o novo prazo acordado.\n\n� 2�. Caso n\�o ocorra a renova\�\�o pelas partes no final do prazo acima referido, este contrato ser\� automaticamente rescindido sem que haja a necessidade de aviso pr\�vio.\n\nCL�USULA 3� - DA RETRIBUI\�\�O\n\nPela presta\�\�o dos servi\�os o CONTRATANTE pagar\� \� CONTRATADA a quantia de R$ 0,00 (zero reais), que ser\� paga da seguinte maneira:\n\n___________________\n\n� 1�. Dever\� o pagamento acordado neste instrumento ser efetuado por meio de transfer\�ncia banc\�ria por pix utilizando a chave __________________.\n\n� 2�. O CONTRATANTE n\�o vindo a efetuar o pagamento, fica obrigado a pagar multa de 0% (zero por cento) sobre o valor devido, bem como juros de mora de 1% (um por cento) ao m\�s, mais corre\�\�o monet\�ria apurada conforme varia\�\�o do IGP-M no per\�odo.\n\nCL�USULA 4� - DAS OBRIGA\�\�ES DA CONTRATADA\n\nSem preju\�zo de outras disposi\��es deste contrato, constituem obriga\��es da CONTRATADA:\n\nI. prestar os servi\�os contratados na forma e modo ajustados, dentro das normas, dando plena e total garantia dos mesmos;\n\nII. executar os servi\�os contratados utilizando a melhor did\�tica e aplicabilidade, visando sempre atingir o melhor resultado, sob sua exclusiva responsabilidade, sendo-lhe vedada a transfer\�ncia dos mesmos a terceiros, sem pr\�via e expressa concord\�ncia do CONTRATANTE;\n\nIII. ser respons\�vel pelos atos praticados por seus respons\�veis, bem como pelos danos que os mesmos venham a causar para o CONTRATANTE, desde que comprovados, em decorr\�ncia da presta\�\�o dos servi\�os prestados neste contrato;\n\nIV. cumprir todas as determina\��es impostas pelas autoridades p�blicas competentes;\n\nV. arcar devidamente, nos termos da legisla\�\�o trabalhista, com a remunera\�\�o e demais verbas laborais devidas a seus subordinados, inclusive encargos fiscais e previdenci\�rios referentes \�s rela\��es de trabalho;\n\nVI. arcar com todas as despesas de natureza tribut\�ria decorrentes dos servi\�os especificados neste contrato;\n\nVII. fornecer os equipamentos necess\�rios \� presta\�\�o dos servi\�os.\n\nCL�USULA 5� - DAS OBRIGA\�\�ES DO CONTRATANTE\n\nSem preju\�zo de outras disposi\��es deste contrato, constituem obriga\��es do CONTRATANTE:\n\nI. fornecer \� CONTRATADA todas as informa\��es necess\�rias \� realiza\�\�o do servi\�o, devendo especificar os detalhes necess\�rios \� perfeita execu\�\�o do mesmo, e a forma de como ele deve ser entregue;\n\nII. efetuar o pagamento, nas datas e nos termos definidos neste contrato.\n\nCL�USULA 6� - DA RESCIS\�O\n\nO presente instrumento poder\� ser rescindido caso qualquer uma das partes descumpra o disposto neste contrato.\n\n� 1�. Na hip�tese do CONTRATANTE solicitar a rescis\�o antecipada deste contrato sem justa causa, ser\� obrigado a pagar \� CONTRATADA por inteiro qualquer retribui\�\�o vencida e n\�o paga, e metade do que ela receberia at\� o final do contrato.\n\n� 2�. Na hip�tese da CONTRATADA solicitar a rescis\�o antecipada deste contrato sem justa causa, esta ter\� direito \� retribui\�\�o vencida, mas responder\� por perdas e danos que cause ao CONTRATANTE.\n\n� 3�. A rescis\�o com justa causa por parte do CONTRATANTE obriga a devolu\�\�o pela CONTRATADA de quaisquer valores j\� pagos referentes a servi\�os n\�o desenvolvidos.\n\nCL�USULA 7� - DA EXTIN\�\�O DO CONTRATO\n\nO presente contrato extingue-se sem que assista \�s partes direito a qualquer tipo de indeniza\�\�o, ressarcimento ou multa, por mais especial que seja, nas seguintes hip�teses:\n\nI. por insolv\�ncia, impetra\�\�o ou solicita\�\�o de concordata, ou fal\�ncia, de qualquer uma das partes;\n\nII. por qualquer impossibilidade da continua\�\�o do contrato, motivada por for\�a maior ou caso fortuito.\n\nCL�USULA 8� - DAS CONDI\�\�ES GERAIS\n\nSalvo expressa autoriza\�\�o do CONTRATANTE, n\�o poder\� a CONTRATADA transferir ou subcontratar os servi\�os previstos neste instrumento, sob o risco de ocorrer a rescis\�o imediata.\n\n� 1�. Qualquer condescend\�ncia entre as partes quanto ao cumprimento de qualquer cl\�usula do presente contrato, constituir\� mera toler\�ncia e n\�o importar\� em altera\�\�o ou modifica\�\�o das cl\�usulas contratuais.\n\n� 2�. Qualquer servi\�o adicional, desde que acordado entre as partes, ser\� objeto de termo aditivo ao instrumento original.\n\nCL�USULA 9� - DO FORO\n\nFica desde j\� eleito o foro da comarca de __________________ para serem resolvidas eventuais pend\�ncias decorrentes deste contrato.\n\nPor estarem assim certos e ajustados, firmam os signat\�rios este instrumento em 02 (duas) vias de igual teor e forma.\n\n__________________, __/__/____.\n\n___________________________________\n\nCONTRATANTE: ___________________\n\n___________________________________\n\nCONTRATADA: ___________________\n\nneste ato representando a pessoa jur\�dica ___________________\n\n----------------------------------------------\n\nRefer\�ncia:\n\nLei 10.406\n\n----------------------------------------------\n\nIMPORTANTE:\nEste \� um modelo padr\�o b\�sico.\n\nCaso deseje personalizar o seu contrato, escolhendo outras op\��es, como, por exemplo, se o pagamento ser\� efetuado em parcelas, se ter\� multa por descumprimento, dentre diversas outras personaliza\��es, acesse o nosso modelo:\n\nhttps://www.99contratos.com.br/contrato-prestacao-servico-pf.php\n\nAo utilizar o nosso modelo personaliz\�vel voc\� poder\� elaborar e moldar o seu contrato de acordo com as suas respostas.\n\n');
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
