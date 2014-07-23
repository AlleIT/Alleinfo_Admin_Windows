<?php
require_once("../webadmin/core/Classes/Database.php");
require_once("ClientAssist.php");

$clientassist = new ClientAssist();

switch($_POST['reqaction'])
{
	case "testCreds":
		$clientassist->login();
		break;
		
	case "getHome":
		$clientassist->getHome();
		break;

	case "setHome":
		$clientassist->setHome();
		break;

	case "setNews":
		$clientassist->setNews();
		break;
		
	case "getAllNews":
		$clientassist->getAllNews();
		break;
		
	case "getNewsCount":
		$clientassist->getNewsCount();
		break;
		
	case "removeNews":
		$clientassist->removeNews();
		break;

	default:
		echo "Inte implementerad!";
		break;
}

?>
