<?php
require_once("../webadmin/core/Classes/Database.php");

Class ClientAssist extends Database {
	public function testCreds() {
		$username = htmlentities(strip_tags($_POST['username']));
        	$password = htmlentities(hash("SHA512", $_POST['password']));

        	// check if user exist
        	$query = $this->_link->prepare("SELECT * FROM accounts WHERE username = :username AND password = :password");
        	$query->bindParam(":username", $username, PDO::PARAM_STR);
        	$query->bindParam(":password", $password, PDO::PARAM_STR);
        	$query->execute();

        	if ($query->rowCount() == 1){

			echo "accepted";

        	} else {
            		echo "Inloggningen misslyckades.";
        	}
	}

	public function getHome() {
		$username = htmlentities(strip_tags($_POST['username']));
                $password = htmlentities(hash("SHA512", $_POST['password']));

		// check if user exist
                $query = $this->_link->prepare("SELECT * FROM accounts WHERE username = :username AND password = :password");
                $query->bindParam(":username", $username, PDO::PARAM_STR);
                $query->bindParam(":password", $password, PDO::PARAM_STR);
                $query->execute();

                if ($query->rowCount() == 1){

			$row = $query->fetch(PDO::FETCH_ASSOC);

                        echo "accepted" . $row['logoPath'] . "," . $row['description'] . "," . $row['socialLink'];

                } else {
                        echo "Felaktiga användaruppgifter.";
                }
	}

	public function setHome() {
		$username = htmlentities(strip_tags($_POST['username']));
                $password = htmlentities(hash("SHA512", $_POST['password']));

                // check if user exist
                $query = $this->_link->prepare("SELECT * FROM accounts WHERE username = :username AND password = :password");
                $query->bindParam(":username", $username, PDO::PARAM_STR);
                $query->bindParam(":password", $password, PDO::PARAM_STR);
                $query->execute();

                if ($query->rowCount() != 1){
			die("Felaktiga användaruppgifter");
		}

		$row = $query->fetch(PDO::FETCH_ASSOC);

		$path = "/var/www/AlleIT/Alleinfo/utskottsbilder".strrchr($row['logoPath'], "/");

		$image = htmlentities(strip_tags($_POST['image']));

		$file = fopen($path, "w");
		fwrite($file, base64_decode($image));
		fclose($file);

		$description = htmlentities($_POST['description']);
		$socialLink = htmlentities(strip_tags($_POST['socialURL']));

		$query = $this->_link->prepare("UPDATE `alleit`.`accounts` SET `description` = :description, `socialLink` = :sociallink WHERE `accounts`.`id` =".$row['id']);
                $query->bindParam(":description", $description, PDO::PARAM_STR);
                $query->bindParam(":sociallink", $socialLink, PDO::PARAM_STR);
                $query->execute();

                echo "accepted";
	}
}

?>
