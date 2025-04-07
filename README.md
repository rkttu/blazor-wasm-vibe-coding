# 사칙연산 계산기 - Blazor WebAssembly 애플리케이션

이 프로젝트는 .NET Blazor WebAssembly를 사용하여 개발된 간단한 사칙연산 계산기 웹 애플리케이션입니다. 사용자는 두 숫자에 대해 더하기, 빼기, 곱하기, 나누기 연산을 수행할 수 있습니다.

> **💡 바이브 코딩 데모**: 이 프로젝트는 Visual Studio Cide Insider, GitHub Copilot Edit, 그리고 Claude 3.7 Sonnet을 활용한 바이브 코딩(Vibe Coding) 방식으로 Blazor WASM 프로젝트를 개발하는 과정을 시연하는 데모입니다.

## 지시문

Cursor Rules를 모아놓은 갤러리 웹 사이트인 cursor.directory의 ][Blazor 개발자 Rule](https://cursor.directory/blazor-aspnetcore-cursor-rules) 파일을 GitHub Copilot Edit용 프롬프트로 그대로 가져와서 사용했습니다.

해당 내용을 프로젝트 디렉터리 아래의 `.github/prompts/instruction.prompt.md` 파일로 만들었고, 컨텍스트에 해당 파일을 추가했습니다.

## 프롬프트

Claude 3.7 Sonnet을 사용하여 아래 프롬프트를 순서대로 실행했습니다.

- 새로운 .NET Blazor 웹 어셈블리 애플리케이션을 만들어줘. 사칙연산 계산기 기능을 구현했으면 해.
- 좋아. 이 프로젝트를 설명하고, 개발자 온보딩을 돕는 README.md 파일을 만들어줘.
- README.md 파일을 한 폴더 위로 이동시켜줘.
- CalculatorApp.csproj를 위한 유닛테스트를 추가해줘. 그리고 솔루션 파일은 slnx 포맷으로 만들고, CalculatorApp 폴더는 src 폴더 아래로, slnx 파일은 src 폴더에 만들어줘.
- 좋아. 이 프로젝트에서 Counter, Weather는 더 이상 사용하지 않으니 제거해줘.
- 좋아. 이제 이 프로젝트를 GitHub Pages로 퍼블리싱할 수 있도록 CI/CD 파이프라인을 github action으로 만들어줘.
- 좋아. 이 프로젝트 폴더를 git 리포지터리로 전환하고, Visual Studio와 .NET 프로젝트 기준으로 기본적으로 무시해야 할 파일들을 .gitignore 파일로 넣어줘.
- 좋아. 첫 번째 커밋의 내용을 좀 더 보강했으면 해.
- master 브랜치를 main 브랜치로 이름을 변경했으면 해.
- 좋아. README 파일의 내용을 보강했으면 해. 지금 만들고 있는 프로젝트는 바이브 코딩 방식으로 Blazor WASM 프로젝트를 개발하는 방법을 시연하는 데모여서, 아래 프롬프트를 사용해서 만들었다는 사실을 넣으려 해. (지금까지 넣은 프롬프트 다시 반복)
- 좋아. 지금 편집한 내용을 반영하는 커밋을 추가해줘. 그리고 원격 리포지터리 주소는 https://github.com/rkttu/blazor-wasm-vibe-coding.git 으로 설정해줘.

## 기술 스택

- **프론트엔드**: Blazor WebAssembly (.NET 9.0)
- **UI 프레임워크**: Bootstrap 5 (Blazor WASM 기본 포함)
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