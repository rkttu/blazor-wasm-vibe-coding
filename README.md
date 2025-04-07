# 사칙연산 계산기 - Blazor WebAssembly 애플리케이션

이 프로젝트는 .NET Blazor WebAssembly를 사용하여 개발된 간단한 사칙연산 계산기 웹 애플리케이션입니다. 사용자는 두 숫자에 대해 더하기, 빼기, 곱하기, 나누기 연산을 수행할 수 있습니다.

## 기술 스택

- **프론트엔드**: Blazor WebAssembly (.NET 9.0)
- **UI 프레임워크**: Bootstrap 5
- **테스트 프레임워크**: xUnit
- **CI/CD**: GitHub Actions
- **호스팅**: GitHub Pages

## 기능

- 두 개의 숫자 입력 필드
- 사칙연산(더하기, 빼기, 곱하기, 나누기) 지원
- 0으로 나누기 시 오류 메시지 표시
- 반응형 디자인 (모바일 및 데스크톱 지원)
- 한국어 인터페이스

## 프로젝트 구조

```
/
├── README.md               # 프로젝트 문서
├── .github/                # GitHub 설정 파일
│   └── workflows/          # GitHub Actions 워크플로우
│       └── deploy-to-github-pages.yml  # 배포 워크플로우
├── src/                    # 소스 코드
│   ├── CalculatorApp.slnx  # 솔루션 파일
│   ├── CalculatorApp/      # 주 애플리케이션 프로젝트
│   │   ├── _Imports.razor  # Razor 임포트 설정
│   │   ├── App.razor       # 애플리케이션 루트 컴포넌트
│   │   ├── Program.cs      # 애플리케이션 진입점
│   │   ├── Layout/         # 레이아웃 컴포넌트
│   │   ├── Pages/          # 페이지 컴포넌트
│   │   ├── Services/       # 서비스 클래스
│   │   └── wwwroot/        # 정적 파일
│   └── CalculatorApp.Tests/ # 테스트 프로젝트
│       └── CalculatorServiceTests.cs  # 계산기 서비스 테스트
```

## 아키텍처

이 프로젝트는 다음과 같은 아키텍처 원칙과 패턴을 따릅니다:

1. **계층 분리**: UI 컴포넌트(Pages)와 비즈니스 로직(Services)을 분리하여 관심사 분리 원칙을 구현합니다.

2. **의존성 주입**: 서비스 클래스는 Program.cs에서 DI 컨테이너에 등록되어 컴포넌트에서 주입받아 사용합니다.

3. **컴포넌트 기반 UI**: Blazor의 컴포넌트 모델을 활용하여 재사용 가능한 UI 요소를 구현합니다.

4. **서비스 추상화**: 핵심 비즈니스 로직은 서비스 클래스로 추상화하여 테스트 용이성을 높입니다.

### 데이터 흐름

```
User Input → Razor Component → Service → Calculation → UI Update
```

## 시작하기

### 사전 요구사항

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) 이상
- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) 또는 [Visual Studio Code](https://code.visualstudio.com/)

### 로컬에서 실행하기

1. 저장소 클론하기
   ```
   git clone <repository-url>
   cd CalculatorApp
   ```

2. 프로젝트 빌드 및 실행
   ```
   dotnet build
   dotnet run
   ```
   또는 Visual Studio에서 프로젝트를 열고 F5 키를 눌러 디버그 모드로 실행하거나, Ctrl+F5를 눌러 디버그 없이 실행할 수 있습니다.

3. 웹 브라우저에서 `https://localhost:5001` 또는 `http://localhost:5000`으로 접속합니다.

## 테스트 전략

이 프로젝트는 다음과 같은 테스트 방식을 채택하고 있습니다:

1. **단위 테스트**: 서비스 클래스의 기능을 검증하는 단위 테스트를 xUnit 프레임워크로 구현했습니다.

2. **테스트 케이스**: 
   - 기본 연산 테스트: 각 사칙연산의 기본 기능 검증
   - 특수 케이스 테스트: 0으로 나누기와 같은 예외 상황 처리 검증
   - 다양한 입력값 테스트: 다양한 숫자 조합에 대한 연산 결과 검증

테스트는 Visual Studio에서 Test Explorer를 통해 실행하거나 명령줄에서 다음 명령으로 실행할 수 있습니다:

```bash
cd src
dotnet test
```

## 주요 구성 요소

### Calculator.razor

계산기의 핵심 기능을 구현하는 Razor 컴포넌트입니다. 이 컴포넌트는 다음과 같은 기능을 제공합니다:

- 두 숫자 입력 필드
- 사칙연산 버튼
- 결과 표시
- 오류 메시지 처리

```csharp
private void Calculate(Operation operation)
{
    errorMessage = string.Empty;

    try
    {
        switch (operation)
        {
            case Operation.Add:
                result = firstNumber + secondNumber;
                break;
            case Operation.Subtract:
                result = firstNumber - secondNumber;
                break;
            case Operation.Multiply:
                result = firstNumber * secondNumber;
                break;
            case Operation.Divide:
                if (secondNumber == 0)
                {
                    errorMessage = "0으로 나눌 수 없습니다.";
                    return;
                }
                result = firstNumber / secondNumber;
                break;
        }
    }
    catch (Exception ex)
    {
        errorMessage = $"계산 중 오류가 발생했습니다: {ex.Message}";
    }
}
```

## 스타일링

계산기 UI는 Bootstrap과 사용자 정의 CSS를 사용하여 구현되었습니다. 주요 스타일은 `wwwroot/css/app.css` 파일에 정의되어 있습니다.

## 향후 개선사항

- 메모리 기능 추가 (이전 결과 저장 및 불러오기)
- 더 복잡한 연산 추가 (제곱, 제곱근, 삼각함수 등)
- 계산 히스토리 기능
- 테마 선택 옵션
- 단위 변환 기능

## 개발자 가이드

### 코드 스타일 및 구조
- PascalCase를 컴포넌트 이름, 메서드 이름 및 공개 멤버에 사용합니다.
- camelCase를 비공개 필드 및 지역 변수에 사용합니다.
- 인터페이스 이름에는 "I" 접두사를 사용합니다(예: IUserService).

### 구성 요소 추가
새로운 연산이나 기능을 추가하려면:

1. `Calculator.razor`의 Operation enum에 새 연산을 추가합니다.
2. Calculate 메서드에 새 연산에 대한 case를 추가합니다.
3. 해당 버튼을 UI에 추가합니다.

### 성능 최적화
- 불필요한 다시 렌더링을 피하기 위해 `ShouldRender()`를 사용하세요.
- 상태 변경 이벤트에 `StateHasChanged()`를 효율적으로 사용하세요.

## CI/CD 및 배포

이 프로젝트는 GitHub Actions를 사용하여 GitHub Pages에 자동으로 배포됩니다. 워크플로우는 다음과 같은 단계로 구성됩니다:

1. `main` 브랜치에 푸시하면 자동으로 워크플로우가 실행됩니다
2. .NET 환경 설정 및 프로젝트 빌드
3. 정적 웹 자산 생성 및 GitHub Pages를 위한 설정
4. `gh-pages` 브랜치에 배포

GitHub Pages URL: https://[username].github.io/[repository-name]/

## 라이센스

이 프로젝트는 MIT 라이센스에 따라 라이센스가 부여됩니다. 자세한 내용은 LICENSE 파일을 참조하세요.