<?php
require_once("../webadmin/core/Classes/Database.php");

Class ClientAssist extends Database {

	private $query;

	public function login() {
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
            echo "accepted" . $row['logoPath'] . "," . $row['description'] . "," . $row['socialLink'] . $row['color'];
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
		$color = htmlentities(strip_tags($_POST['color']));

		$query = $this->_link->prepare("UPDATE `alleit`.`accounts` SET `description` = :description, `socialLink` = :sociallink, `color` = :color WHERE `accounts`.`id` =".$row['id']);
                $query->bindParam(":description", $description, PDO::PARAM_STR);
                $query->bindParam(":sociallink", $socialLink, PDO::PARAM_STR);
                $query->bindParam(":color", $color, PDO::PARAM_STR);
                $query->execute();

                echo "accepted";
	}
	
	public function setNews() {
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

		$id = htmlentities(strip_tags($_POST['id']));
		$headline = htmlentities(strip_tags($_POST['headline']));
		$shortDesc = htmlentities($_POST['shortDesc']);
		$butUrl = htmlentities(strip_tags($_POST['butUrl']));
		$description = htmlentities($_POST['description']);
		$type = htmlentities(strip_tags($_POST['type']));
		$date = htmlentities(strip_tags($_POST['pubDate']));
				
		if($id == -1)
		{
			$query = $this->_link->prepare("INSERT INTO `alleit`.`elevkaren_news` (`headline`, `shortInfo`, `description`, `butURL`, `type`, `handler`, `pubDate`) VALUES (:headline, :shortDesc, :description, :butUrl, :type, :handler, :date);");
            $query->bindParam(":headline", $headline, PDO::PARAM_STR);
            $query->bindParam(":shortDesc", $shortDesc, PDO::PARAM_STR);
            $query->bindParam(":description", $description, PDO::PARAM_STR);
            $query->bindParam(":butUrl", $butUrl, PDO::PARAM_STR);
            $query->bindParam(":type", $type, PDO::PARAM_STR);
            $query->bindParam(":handler", $row['handler'], PDO::PARAM_STR);
            $query->bindParam(":date", $date, PDO::PARAM_STR);
            $query->execute();

            echo "accepted";
		} else {
			$query = $this->_link->prepare("UPDATE `alleit`.`elevkaren_news` SET  `headline` =  :headline, `shortInfo` =  :shortDesc, `description` =  :description, `butURL` =  :butUrl, `type` =  :type, `handler` =  :handler WHERE  `elevkaren_news`.`id` = :id;");
            $query->bindParam(":headline", $headline, PDO::PARAM_STR);
            $query->bindParam(":shortDesc", $shortDesc, PDO::PARAM_STR);
            $query->bindParam(":description", $description, PDO::PARAM_STR);
            $query->bindParam(":butUrl", $butUrl, PDO::PARAM_STR);
            $query->bindParam(":type", $type, PDO::PARAM_STR);
            $query->bindParam(":handler", $row['handler'], PDO::PARAM_STR);
            $query->bindParam(":id", $id, PDO::PARAM_STR);
            $query->execute();
			
            echo "accepted";
		}
	}
}

?>
