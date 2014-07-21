<?php
require_once("../webadmin/core/Classes/Database.php");
require_once("ClientAssist.php");

$clientassist = new ClientAssist();

switch($_POST['reqaction'])
{
	case "testCreds":
		$clientassist->testCreds();
		break;
	case "getHome":
		$clientassist->getHome();
		break;

	case "setHome":
		$clientassist->setHome();
		break;

	default:
		echo "Inte implementerad!";
		break;
}

?>
