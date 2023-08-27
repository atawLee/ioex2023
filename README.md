# ioex2023
Blazor eCommerce 발표용 샘플 코드 

- 발표용으로 이미지 저장부분을 Client 정적파일 위치로 지정하여서, 이미지 저장 부분 주석처리 되있습니다.
  (정상적인 시나리오는 로컬의 다른 경로로 nginx 설정으로 이미지 디렉토리 위치 지정하고 그위치에 저장하도록 설정하거나, CDN 서비스를 사용합니다.)
- 사용된 테이블 스키마 생성문 입니다. mysql을 사용했습니다.
```CREATE TABLE Users (
    userId INT PRIMARY KEY AUTO_INCREMENT,
    email VARCHAR(255) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    username VARCHAR(100) NOT NULL,
    role VARCHAR(50) NOT NULL DEFAULT 'USER'
);
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY AUTO_INCREMENT,
    CategoryName VARCHAR(100) NOT NULL
);
CREATE TABLE Products (
    productId INT PRIMARY KEY AUTO_INCREMENT,
    userId INT,
    productName VARCHAR(255) NOT NULL,
    CategoryId INT,
    price DECIMAL(10, 2) NOT NULL,
    content TEXT,
    imageUrl VARCHAR(500),
    registrationDate DATETIME NOT NULL,
    isActive TINYINT(1) NOT NULL DEFAULT 1,
    FOREIGN KEY (userId) REFERENCES Users(userId) ON DELETE SET NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId) ON DELETE SET NULL
);
CREATE TABLE Cart (
    cartId INT PRIMARY KEY AUTO_INCREMENT,
    userId INT,
    productId INT,
    quantity INT NOT NULL DEFAULT 1,
    FOREIGN KEY (userId) REFERENCES Users(userId) ON DELETE SET NULL,
    FOREIGN KEY (productId) REFERENCES Products(productId) ON DELETE SET NULL
);

```
