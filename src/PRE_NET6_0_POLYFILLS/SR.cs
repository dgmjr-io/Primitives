#if !NET6_0_OR_GREATER
#region Assembly System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
// /usr/local/share/dotnet/shared/Microsoft.NETCore.App/8.0.0-preview.5.23280.8/System.Private.CoreLib.dll
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

using System.Collections.Generic;
using System.IO;
// using System.Private.CoreLib;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System;

public static class SR
{
    private static readonly object _lock = new object();

    private static ResourceManager s_resourceManager;

    public static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(SR)));

    private static bool UsingResourceKeys() => true;

    public const string Acc_CreateAbstEx = "Acc_CreateAbstEx";

    public const string Acc_CreateArgIterator = "Acc_CreateArgIterator";

    public const string Acc_CreateGenericEx = "Acc_CreateGenericEx";

    public const string Acc_CreateInterfaceEx = "Acc_CreateInterfaceEx";

    public const string Acc_CreateVoid = "Acc_CreateVoid";

    public const string Acc_NotClassInit = "Acc_NotClassInit";

    public const string Acc_ReadOnly = "Acc_ReadOnly";

    public const string Access_Void = "Access_Void";

    public const string AggregateException_ctor_DefaultMessage = "AggregateException_ctor_DefaultMessage";

    public const string AggregateException_ctor_InnerExceptionNull = "AggregateException_ctor_InnerExceptionNull";

    public const string AggregateException_DeserializationFailure = "AggregateException_DeserializationFailure";

    public const string AggregateException_InnerException = "AggregateException_InnerException";

    public const string AppDomain_Name = "AppDomain_Name";

    public const string AppDomain_NoContextPolicies = "AppDomain_NoContextPolicies";

    public const string AppDomain_Policy_PrincipalTwice = "AppDomain_Policy_PrincipalTwice";

    public const string AmbiguousImplementationException_NullMessage = "AmbiguousImplementationException_NullMessage";

    public const string Arg_AccessException = "Arg_AccessException";

    public const string Arg_AccessViolationException = "Arg_AccessViolationException";

    public const string Arg_AmbiguousMatchException = "Arg_AmbiguousMatchException";

    public const string Arg_ApplicationException = "Arg_ApplicationException";

    public const string Arg_ArgumentException = "Arg_ArgumentException";

    public const string Arg_ArgumentOutOfRangeException = "Arg_ArgumentOutOfRangeException";

    public const string Arg_ArithmeticException = "Arg_ArithmeticException";

    public const string Arg_ArrayLengthsDiffer = "Arg_ArrayLengthsDiffer";

    public const string Arg_ArrayPlusOffTooSmall = "Arg_ArrayPlusOffTooSmall";

    public const string Arg_ByteArrayTooSmallForValue = "Arg_ByteArrayTooSmallForValue";

    public const string Arg_ArrayTypeMismatchException = "Arg_ArrayTypeMismatchException";

    public const string Arg_ArrayZeroError = "Arg_ArrayZeroError";

    public const string Arg_BadDecimal = "Arg_BadDecimal";

    public const string Arg_BadImageFormatException = "Arg_BadImageFormatException";

    public const string Arg_BadLiteralFormat = "Arg_BadLiteralFormat";

    public const string Arg_BogusIComparer = "Arg_BogusIComparer";

    public const string Arg_BufferTooSmall = "Arg_BufferTooSmall";

    public const string Arg_CannotBeNaN = "Arg_CannotBeNaN";

    public const string Arg_CannotHaveNegativeValue = "Arg_CannotHaveNegativeValue";

    public const string Arg_CannotMixComparisonInfrastructure = "Arg_CannotMixComparisonInfrastructure";

    public const string Arg_CannotUnloadAppDomainException = "Arg_CannotUnloadAppDomainException";

    public const string Arg_COMException = "Arg_COMException";

    public const string Arg_CreatInstAccess = "Arg_CreatInstAccess";

    public const string Arg_CryptographyException = "Arg_CryptographyException";

    public const string Arg_CustomAttributeFormatException = "Arg_CustomAttributeFormatException";

    public const string Arg_DataMisalignedException = "Arg_DataMisalignedException";

    public const string Arg_DecBitCtor = "Arg_DecBitCtor";

    public const string Arg_DirectoryNotFoundException = "Arg_DirectoryNotFoundException";

    public const string Arg_DivideByZero = "Arg_DivideByZero";

    public const string Arg_DlgtNullInst = "Arg_DlgtNullInst";

    public const string Arg_DlgtTargMeth = "Arg_DlgtTargMeth";

    public const string Arg_DlgtTypeMis = "Arg_DlgtTypeMis";

    public const string Arg_DllNotFoundException = "Arg_DllNotFoundException";

    public const string Arg_DuplicateWaitObjectException = "Arg_DuplicateWaitObjectException";

    public const string Arg_EHClauseNotClause = "Arg_EHClauseNotClause";

    public const string Arg_EHClauseNotFilter = "Arg_EHClauseNotFilter";

    public const string Arg_EmptyArray = "Arg_EmptyArray";

    public const string Arg_EmptySpan = "Arg_EmptySpan";

    public const string Arg_EndOfStreamException = "Arg_EndOfStreamException";

    public const string Arg_EntryPointNotFoundException = "Arg_EntryPointNotFoundException";

    public const string Arg_EnumAndObjectMustBeSameType = "Arg_EnumAndObjectMustBeSameType";

    public const string Arg_EnumFormatUnderlyingTypeAndObjectMustBeSameType = "Arg_EnumFormatUnderlyingTypeAndObjectMustBeSameType";

    public const string Arg_EnumIllegalVal = "Arg_EnumIllegalVal";

    public const string Arg_EnumLitValueNotFound = "Arg_EnumLitValueNotFound";

    public const string Arg_EnumUnderlyingTypeAndObjectMustBeSameType = "Arg_EnumUnderlyingTypeAndObjectMustBeSameType";

    public const string Arg_EnumValueNotFound = "Arg_EnumValueNotFound";

    public const string Arg_ExecutionEngineException = "Arg_ExecutionEngineException";

    public const string Arg_ExternalException = "Arg_ExternalException";

    public const string Arg_FieldAccessException = "Arg_FieldAccessException";

    public const string Arg_FieldDeclTarget = "Arg_FieldDeclTarget";

    public const string Arg_FldGetArgErr = "Arg_FldGetArgErr";

    public const string Arg_FldGetPropSet = "Arg_FldGetPropSet";

    public const string Arg_FldSetArgErr = "Arg_FldSetArgErr";

    public const string Arg_FldSetGet = "Arg_FldSetGet";

    public const string Arg_FldSetInvoke = "Arg_FldSetInvoke";

    public const string Arg_FldSetPropGet = "Arg_FldSetPropGet";

    public const string Arg_FormatException = "Arg_FormatException";

    public const string Arg_GenericParameter = "Arg_GenericParameter";

    public const string Arg_GetMethNotFnd = "Arg_GetMethNotFnd";

    public const string Arg_GuidArrayCtor = "Arg_GuidArrayCtor";

    public const string Arg_HandleNotAsync = "Arg_HandleNotAsync";

    public const string Arg_HandleNotSync = "Arg_HandleNotSync";

    public const string Arg_HexBinaryStylesNotSupported = "Arg_HexBinaryStylesNotSupported";

    public const string Arg_HTCapacityOverflow = "Arg_HTCapacityOverflow";

    public const string Arg_IndexMustBeInt = "Arg_IndexMustBeInt";

    public const string Arg_IndexOutOfRangeException = "Arg_IndexOutOfRangeException";

    public const string Arg_InsufficientExecutionStackException = "Arg_InsufficientExecutionStackException";

    public const string Arg_InvalidBase = "Arg_InvalidBase";

    public const string Arg_InvalidCastException = "Arg_InvalidCastException";

    public const string Arg_InvalidComObjectException = "Arg_InvalidComObjectException";

    public const string Arg_InvalidFilterCriteriaException = "Arg_InvalidFilterCriteriaException";

    public const string Arg_InvalidHandle = "Arg_InvalidHandle";

    public const string Arg_InvalidHexBinaryStyle = "Arg_InvalidHexBinaryStyle";

    public const string Arg_InvalidNeutralResourcesLanguage_Asm_Culture = "Arg_InvalidNeutralResourcesLanguage_Asm_Culture";

    public const string Arg_InvalidNeutralResourcesLanguage_FallbackLoc = "Arg_InvalidNeutralResourcesLanguage_FallbackLoc";

    public const string Arg_InvalidSatelliteContract_Asm_Ver = "Arg_InvalidSatelliteContract_Asm_Ver";

    public const string Arg_InvalidOleVariantTypeException = "Arg_InvalidOleVariantTypeException";

    public const string Arg_InvalidOperationException = "Arg_InvalidOperationException";

    public const string Arg_InvalidTypeInRetType = "Arg_InvalidTypeInRetType";

    public const string Arg_InvalidTypeInSignature = "Arg_InvalidTypeInSignature";

    public const string Arg_IOException = "Arg_IOException";

    public const string Arg_KeyNotFound = "Arg_KeyNotFound";

    public const string Arg_KeyNotFoundWithKey = "Arg_KeyNotFoundWithKey";

    public const string Arg_LongerThanDestArray = "Arg_LongerThanDestArray";

    public const string Arg_LongerThanSrcArray = "Arg_LongerThanSrcArray";

    public const string Arg_LongerThanSrcString = "Arg_LongerThanSrcString";

    public const string Arg_LowerBoundsMustMatch = "Arg_LowerBoundsMustMatch";

    public const string Arg_MarshalAsAnyRestriction = "Arg_MarshalAsAnyRestriction";

    public const string Arg_MarshalDirectiveException = "Arg_MarshalDirectiveException";

    public const string Arg_MethodAccessException = "Arg_MethodAccessException";

    public const string Arg_MissingFieldException = "Arg_MissingFieldException";

    public const string Arg_MissingManifestResourceException = "Arg_MissingManifestResourceException";

    public const string Arg_MissingMemberException = "Arg_MissingMemberException";

    public const string Arg_MissingMethodException = "Arg_MissingMethodException";

    public const string Arg_MulticastNotSupportedException = "Arg_MulticastNotSupportedException";

    public const string Arg_MustBeBoolean = "Arg_MustBeBoolean";

    public const string Arg_MustBeByte = "Arg_MustBeByte";

    public const string Arg_MustBeChar = "Arg_MustBeChar";

    public const string Arg_MustBeDateOnly = "Arg_MustBeDateOnly";

    public const string Arg_MustBeTimeOnly = "Arg_MustBeTimeOnly";

    public const string Arg_MustBeDateTime = "Arg_MustBeDateTime";

    public const string Arg_MustBeDateTimeOffset = "Arg_MustBeDateTimeOffset";

    public const string Arg_MustBeDecimal = "Arg_MustBeDecimal";

    public const string Arg_MustBeDelegate = "Arg_MustBeDelegate";

    public const string Arg_MustBeDouble = "Arg_MustBeDouble";

    public const string Arg_MustBeEnum = "Arg_MustBeEnum";

    public const string Arg_MustBeEnumBaseTypeOrEnum = "Arg_MustBeEnumBaseTypeOrEnum";

    public const string Arg_MustBeGuid = "Arg_MustBeGuid";

    public const string Arg_MustBeInt16 = "Arg_MustBeInt16";

    public const string Arg_MustBeInt32 = "Arg_MustBeInt32";

    public const string Arg_MustBeInt64 = "Arg_MustBeInt64";

    public const string Arg_MustBeInt128 = "Arg_MustBeInt128";

    public const string Arg_MustBeIntPtr = "Arg_MustBeIntPtr";

    public const string Arg_MustBeNFloat = "Arg_MustBeNFloat";

    public const string Arg_MustBePointer = "Arg_MustBePointer";

    public const string Arg_MustBePrimArray = "Arg_MustBePrimArray";

    public const string Arg_MustBeRuntimeAssembly = "Arg_MustBeRuntimeAssembly";

    public const string Arg_MustBeSByte = "Arg_MustBeSByte";

    public const string Arg_MustBeSingle = "Arg_MustBeSingle";

    public const string Arg_MustBeString = "Arg_MustBeString";

    public const string Arg_MustBeTimeSpan = "Arg_MustBeTimeSpan";

    public const string Arg_MustBeType = "Arg_MustBeType";

    public const string Arg_MustBeTrue = "Arg_MustBeTrue";

    public const string Arg_MustBeUInt16 = "Arg_MustBeUInt16";

    public const string Arg_MustBeUInt32 = "Arg_MustBeUInt32";

    public const string Arg_MustBeUInt64 = "Arg_MustBeUInt64";

    public const string Arg_MustBeUInt128 = "Arg_MustBeUInt128";

    public const string Arg_MustBeUIntPtr = "Arg_MustBeUIntPtr";

    public const string Arg_MustBeVersion = "Arg_MustBeVersion";

    public const string Arg_MustContainEnumInfo = "Arg_MustContainEnumInfo";

    public const string Arg_NamedParamNull = "Arg_NamedParamNull";

    public const string Arg_NamedParamTooBig = "Arg_NamedParamTooBig";

    public const string Arg_NDirectBadObject = "Arg_NDirectBadObject";

    public const string Arg_Need1DArray = "Arg_Need1DArray";

    public const string Arg_Need2DArray = "Arg_Need2DArray";

    public const string Arg_Need3DArray = "Arg_Need3DArray";

    public const string Arg_NeedAtLeast1Rank = "Arg_NeedAtLeast1Rank";

    public const string Arg_NoAccessSpec = "Arg_NoAccessSpec";

    public const string Arg_NoDefCTorWithoutTypeName = "Arg_NoDefCTorWithoutTypeName";

    public const string Arg_NoDefCTor = "Arg_NoDefCTor";

    public const string Arg_NonZeroLowerBound = "Arg_NonZeroLowerBound";

    public const string Arg_NoStaticVirtual = "Arg_NoStaticVirtual";

    public const string Arg_NotFiniteNumberException = "Arg_NotFiniteNumberException";

    public const string Arg_NotGenericMethodDefinition = "Arg_NotGenericMethodDefinition";

    public const string Arg_NotGenericParameter = "Arg_NotGenericParameter";

    public const string Arg_NotGenericTypeDefinition = "Arg_NotGenericTypeDefinition";

    public const string Arg_NotImplementedException = "Arg_NotImplementedException";

    public const string Arg_NotSupportedException = "Arg_NotSupportedException";

    public const string Arg_NullReferenceException = "Arg_NullReferenceException";

    public const string Arg_ObjObjEx = "Arg_ObjObjEx";

    public const string Arg_OleAutDateInvalid = "Arg_OleAutDateInvalid";

    public const string Arg_OleAutDateScale = "Arg_OleAutDateScale";

    public const string Arg_OverflowException = "Arg_OverflowException";

    public const string Arg_ParamName_Name = "Arg_ParamName_Name";

    public const string Arg_ParmArraySize = "Arg_ParmArraySize";

    public const string Arg_ParmCnt = "Arg_ParmCnt";

    public const string Arg_PathEmpty = "Arg_PathEmpty";

    public const string Arg_PlatformNotSupported = "Arg_PlatformNotSupported";

    public const string Arg_PropSetGet = "Arg_PropSetGet";

    public const string Arg_PropSetInvoke = "Arg_PropSetInvoke";

    public const string Arg_RankException = "Arg_RankException";

    public const string Arg_RankIndices = "Arg_RankIndices";

    public const string Arg_RankMultiDimNotSupported = "Arg_RankMultiDimNotSupported";

    public const string Arg_RanksAndBounds = "Arg_RanksAndBounds";

    public const string Arg_ResMgrNotResSet = "Arg_ResMgrNotResSet";

    public const string Arg_ResourceFileUnsupportedVersion = "Arg_ResourceFileUnsupportedVersion";

    public const string Arg_ResourceNameNotExist = "Arg_ResourceNameNotExist";

    public const string Arg_SafeArrayRankMismatchException = "Arg_SafeArrayRankMismatchException";

    public const string Arg_SafeArrayTypeMismatchException = "Arg_SafeArrayTypeMismatchException";

    public const string Arg_SecurityException = "Arg_SecurityException";

    public const string SerializationException = "SerializationException";

    public const string Arg_SetMethNotFnd = "Arg_SetMethNotFnd";

    public const string Arg_StackOverflowException = "Arg_StackOverflowException";

    public const string Arg_SurrogatesNotAllowedAsSingleChar = "Arg_SurrogatesNotAllowedAsSingleChar";

    public const string Arg_SynchronizationLockException = "Arg_SynchronizationLockException";

    public const string Arg_SystemException = "Arg_SystemException";

    public const string Arg_TargetInvocationException = "Arg_TargetInvocationException";

    public const string Arg_TargetParameterCountException = "Arg_TargetParameterCountException";

    public const string Arg_ThreadStartException = "Arg_ThreadStartException";

    public const string Arg_ThreadStateException = "Arg_ThreadStateException";

    public const string Arg_TimeoutException = "Arg_TimeoutException";

    public const string Arg_TypeAccessException = "Arg_TypeAccessException";

    public const string Arg_TypedReference_Null = "Arg_TypedReference_Null";

    public const string Arg_TypeLoadException = "Arg_TypeLoadException";

    public const string Arg_TypeLoadNullStr = "Arg_TypeLoadNullStr";

    public const string Arg_TypeRefPrimitive = "Arg_TypeRefPrimitive";

    public const string Arg_TypeUnloadedException = "Arg_TypeUnloadedException";

    public const string Arg_UnauthorizedAccessException = "Arg_UnauthorizedAccessException";

    public const string Arg_UnboundGenField = "Arg_UnboundGenField";

    public const string Arg_UnboundGenParam = "Arg_UnboundGenParam";

    public const string Arg_UnknownTypeCode = "Arg_UnknownTypeCode";

    public const string Arg_UnreachableException = "Arg_UnreachableException";

    public const string Arg_VarMissNull = "Arg_VarMissNull";

    public const string Arg_VersionString = "Arg_VersionString";

    public const string Arg_WrongType = "Arg_WrongType";

    public const string Argument_AbsolutePathRequired = "Argument_AbsolutePathRequired";

    public const string Argument_AddingDuplicate = "Argument_AddingDuplicate";

    public const string Argument_AddingDuplicate__ = "Argument_AddingDuplicate__";

    public const string Argument_AddingDuplicateWithKey = "Argument_AddingDuplicateWithKey";

    public const string Argument_AdjustmentRulesNoNulls = "Argument_AdjustmentRulesNoNulls";

    public const string Argument_AdjustmentRulesOutOfOrder = "Argument_AdjustmentRulesOutOfOrder";

    public const string Argument_AlignmentMustBePow2 = "Argument_AlignmentMustBePow2";

    public const string Argument_ArrayGetInterfaceMap = "Argument_ArrayGetInterfaceMap";

    public const string Argument_ArraysInvalid = "Argument_ArraysInvalid";

    public const string Argument_AttributeNamesMustBeUnique = "Argument_AttributeNamesMustBeUnique";

    public const string Argument_BadConstructor = "Argument_BadConstructor";

    public const string Argument_BadConstructorCallConv = "Argument_BadConstructorCallConv";

    public const string Argument_BadExceptionCodeGen = "Argument_BadExceptionCodeGen";

    public const string Argument_BadFieldForConstructorBuilder = "Argument_BadFieldForConstructorBuilder";

    public const string Argument_BadFieldSig = "Argument_BadFieldSig";

    public const string Argument_BadFieldType = "Argument_BadFieldType";

    public const string Argument_BadFormatSpecifier = "Argument_BadFormatSpecifier";

    public const string Argument_BadImageFormatExceptionResolve = "Argument_BadImageFormatExceptionResolve";

    public const string Argument_BadLabel = "Argument_BadLabel";

    public const string Argument_BadLabelContent = "Argument_BadLabelContent";

    public const string Argument_BadNestedTypeFlags = "Argument_BadNestedTypeFlags";

    public const string Argument_BadParameterCountsForConstructor = "Argument_BadParameterCountsForConstructor";

    public const string Argument_BadParameterTypeForCAB = "Argument_BadParameterTypeForCAB";

    public const string Argument_BadPropertyForConstructorBuilder = "Argument_BadPropertyForConstructorBuilder";

    public const string Argument_BadSigFormat = "Argument_BadSigFormat";

    public const string Argument_BadSizeForData = "Argument_BadSizeForData";

    public const string Argument_BadTypeAttrInvalidLayout = "Argument_BadTypeAttrInvalidLayout";

    public const string Argument_BadTypeAttrNestedVisibilityOnNonNestedType = "Argument_BadTypeAttrNestedVisibilityOnNonNestedType";

    public const string Argument_BadTypeAttrNonNestedVisibilityNestedType = "Argument_BadTypeAttrNonNestedVisibilityNestedType";

    public const string Argument_BadTypeAttrReservedBitsSet = "Argument_BadTypeAttrReservedBitsSet";

    public const string Argument_BadTypeInCustomAttribute = "Argument_BadTypeInCustomAttribute";

    public const string Argument_CannotSetParentToInterface = "Argument_CannotSetParentToInterface";

    public const string Argument_CodepageNotSupported = "Argument_CodepageNotSupported";

    public const string Argument_CompareOptionOrdinal = "Argument_CompareOptionOrdinal";

    public const string Argument_ConflictingDateTimeRoundtripStyles = "Argument_ConflictingDateTimeRoundtripStyles";

    public const string Argument_ConflictingDateTimeStyles = "Argument_ConflictingDateTimeStyles";

    public const string Argument_ConstantDoesntMatch = "Argument_ConstantDoesntMatch";

    public const string Argument_ConstantNotSupported = "Argument_ConstantNotSupported";

    public const string Argument_ConstantNull = "Argument_ConstantNull";

    public const string Argument_ConstructorNeedGenericDeclaringType = "Argument_ConstructorNeedGenericDeclaringType";

    public const string Argument_ConversionOverflow = "Argument_ConversionOverflow";

    public const string Argument_ConvertMismatch = "Argument_ConvertMismatch";

    public const string Argument_CultureIetfNotSupported = "Argument_CultureIetfNotSupported";

    public const string Argument_CultureInvalidIdentifier = "Argument_CultureInvalidIdentifier";

    public const string Argument_CultureIsNeutral = "Argument_CultureIsNeutral";

    public const string Argument_CultureNotSupported = "Argument_CultureNotSupported";

    public const string Argument_CultureNotSupportedInInvariantMode = "Argument_CultureNotSupportedInInvariantMode";

    public const string Argument_CustomAssemblyLoadContextRequestedNameMismatch = "Argument_CustomAssemblyLoadContextRequestedNameMismatch";

    public const string Argument_CustomCultureCannotBePassedByNumber = "Argument_CustomCultureCannotBePassedByNumber";

    public const string Argument_DateTimeBadBinaryData = "Argument_DateTimeBadBinaryData";

    public const string Argument_DateTimeHasTicks = "Argument_DateTimeHasTicks";

    public const string Argument_DateTimeHasTimeOfDay = "Argument_DateTimeHasTimeOfDay";

    public const string Argument_DateTimeIsInvalid = "Argument_DateTimeIsInvalid";

    public const string Argument_DateTimeIsNotAmbiguous = "Argument_DateTimeIsNotAmbiguous";

    public const string Argument_DateTimeKindMustBeUnspecified = "Argument_DateTimeKindMustBeUnspecified";

    public const string Argument_DateTimeKindMustBeUnspecifiedOrUtc = "Argument_DateTimeKindMustBeUnspecifiedOrUtc";

    public const string Argument_DateTimeOffsetInvalidDateTimeStyles = "Argument_DateTimeOffsetInvalidDateTimeStyles";

    public const string Argument_DateTimeOffsetIsNotAmbiguous = "Argument_DateTimeOffsetIsNotAmbiguous";

    public const string Argument_DestinationTooShort = "Argument_DestinationTooShort";

    public const string Argument_DuplicateTypeName = "Argument_DuplicateTypeName";

    public const string Argument_EmitWriteLineType = "Argument_EmitWriteLineType";

    public const string Argument_EmptyWaithandleArray = "Argument_EmptyWaithandleArray";

    public const string Argument_EncoderFallbackNotEmpty = "Argument_EncoderFallbackNotEmpty";

    public const string Argument_EncodingConversionOverflowBytes = "Argument_EncodingConversionOverflowBytes";

    public const string Argument_EncodingConversionOverflowChars = "Argument_EncodingConversionOverflowChars";

    public const string Argument_EncodingNotSupported = "Argument_EncodingNotSupported";

    public const string Argument_EnumTypeDoesNotMatch = "Argument_EnumTypeDoesNotMatch";

    public const string Argument_FallbackBufferNotEmpty = "Argument_FallbackBufferNotEmpty";

    public const string Argument_FieldDeclaringTypeGeneric = "Argument_FieldDeclaringTypeGeneric";

    public const string Argument_FieldNeedGenericDeclaringType = "Argument_FieldNeedGenericDeclaringType";

    public const string Argument_GenConstraintViolation = "Argument_GenConstraintViolation";

    public const string Argument_GenericArgsCount = "Argument_GenericArgsCount";

    public const string Argument_GenericsInvalid = "Argument_GenericsInvalid";

    public const string Argument_GlobalMembersMustBeStatic = "Argument_GlobalMembersMustBeStatic";

    public const string Argument_HasToBeArrayClass = "Argument_HasToBeArrayClass";

    public const string Argument_IdnBadBidi = "Argument_IdnBadBidi";

    public const string Argument_IdnBadLabelSize = "Argument_IdnBadLabelSize";

    public const string Argument_IdnBadNameSize = "Argument_IdnBadNameSize";

    public const string Argument_IdnBadPunycode = "Argument_IdnBadPunycode";

    public const string Argument_IdnBadStd3 = "Argument_IdnBadStd3";

    public const string Argument_IdnIllegalName = "Argument_IdnIllegalName";

    public const string Argument_IllegalEnvVarName = "Argument_IllegalEnvVarName";

    public const string Argument_IllegalName = "Argument_IllegalName";

    public const string Argument_ImplementIComparable = "Argument_ImplementIComparable";

    public const string Argument_InvalidAppendMode = "Argument_InvalidAppendMode";

    public const string Argument_InvalidPreallocateAccess = "Argument_InvalidPreallocateAccess";

    public const string Argument_InvalidPreallocateMode = "Argument_InvalidPreallocateMode";

    public const string Argument_InvalidUnixCreateMode = "Argument_InvalidUnixCreateMode";

    public const string Argument_InvalidArgumentForComparison = "Argument_InvalidArgumentForComparison";

    public const string Argument_InvalidArrayLength = "Argument_InvalidArrayLength";

    public const string Argument_IncompatibleArrayType = "Argument_IncompatibleArrayType";

    public const string InvalidAssemblyName = "InvalidAssemblyName";

    public const string Argument_InvalidCalendar = "Argument_InvalidCalendar";

    public const string Argument_InvalidCharSequence = "Argument_InvalidCharSequence";

    public const string Argument_InvalidCharSequenceNoIndex = "Argument_InvalidCharSequenceNoIndex";

    public const string Argument_InvalidCodePageBytesIndex = "Argument_InvalidCodePageBytesIndex";

    public const string Argument_InvalidCodePageConversionIndex = "Argument_InvalidCodePageConversionIndex";

    public const string Argument_InvalidConstructorDeclaringType = "Argument_InvalidConstructorDeclaringType";

    public const string Argument_InvalidConstructorInfo = "Argument_InvalidConstructorInfo";

    public const string Argument_InvalidCultureName = "Argument_InvalidCultureName";

    public const string Argument_InvalidPredefinedCultureName = "Argument_InvalidPredefinedCultureName";

    public const string Argument_InvalidDateTimeKind = "Argument_InvalidDateTimeKind";

    public const string Argument_InvalidDateTimeStyles = "Argument_InvalidDateTimeStyles";

    public const string Argument_InvalidDateStyles = "Argument_InvalidDateStyles";

    public const string Argument_InvalidDigitSubstitution = "Argument_InvalidDigitSubstitution";

    public const string Argument_InvalidElementName = "Argument_InvalidElementName";

    public const string Argument_InvalidElementTag = "Argument_InvalidElementTag";

    public const string Argument_InvalidElementText = "Argument_InvalidElementText";

    public const string Argument_InvalidElementValue = "Argument_InvalidElementValue";

    public const string Argument_InvalidEnum = "Argument_InvalidEnum";

    public const string Argument_InvalidEnumValue = "Argument_InvalidEnumValue";

    public const string Argument_InvalidFieldDeclaringType = "Argument_InvalidFieldDeclaringType";

    public const string Argument_InvalidFileModeAndAccessCombo = "Argument_InvalidFileModeAndAccessCombo";

    public const string Argument_InvalidFlag = "Argument_InvalidFlag";

    public const string Argument_InvalidGenericInstArray = "Argument_InvalidGenericInstArray";

    public const string Argument_InvalidGroupSize = "Argument_InvalidGroupSize";

    public const string Argument_InvalidHandle = "Argument_InvalidHandle";

    public const string Argument_InvalidHighSurrogate = "Argument_InvalidHighSurrogate";

    public const string Argument_InvalidId = "Argument_InvalidId";

    public const string Argument_InvalidKindOfTypeForCA = "Argument_InvalidKindOfTypeForCA";

    public const string Argument_InvalidLabel = "Argument_InvalidLabel";

    public const string Argument_InvalidLowSurrogate = "Argument_InvalidLowSurrogate";

    public const string Argument_InvalidMemberForNamedArgument = "Argument_InvalidMemberForNamedArgument";

    public const string Argument_InvalidMethodDeclaringType = "Argument_InvalidMethodDeclaringType";

    public const string Argument_InvalidName = "Argument_InvalidName";

    public const string Argument_InvalidNativeDigitCount = "Argument_InvalidNativeDigitCount";

    public const string Argument_InvalidNativeDigitValue = "Argument_InvalidNativeDigitValue";

    public const string Argument_InvalidNeutralRegionName = "Argument_InvalidNeutralRegionName";

    public const string Argument_InvalidNormalizationForm = "Argument_InvalidNormalizationForm";

    public const string Argument_InvalidNumberStyles = "Argument_InvalidNumberStyles";

    public const string Argument_InvalidOffLen = "Argument_InvalidOffLen";

    public const string Argument_InvalidOpCodeOnDynamicMethod = "Argument_InvalidOpCodeOnDynamicMethod";

    public const string Argument_InvalidParameterInfo = "Argument_InvalidParameterInfo";

    public const string Argument_InvalidParamInfo = "Argument_InvalidParamInfo";

    public const string Argument_NullCharInPath = "Argument_NullCharInPath";

    public const string Argument_InvalidResourceCultureName = "Argument_InvalidResourceCultureName";

    public const string Argument_InvalidSafeBufferOffLen = "Argument_InvalidSafeBufferOffLen";

    public const string Argument_InvalidSeekOrigin = "Argument_InvalidSeekOrigin";

    public const string Argument_InvalidSerializedString = "Argument_InvalidSerializedString";

    public const string Argument_InvalidStartupHookSignature = "Argument_InvalidStartupHookSignature";

    public const string Argument_InvalidTimeSpanStyles = "Argument_InvalidTimeSpanStyles";

    public const string Argument_InvalidToken = "Argument_InvalidToken";

    public const string Argument_InvalidTypeForCA = "Argument_InvalidTypeForCA";

    public const string Argument_InvalidTypeForDynamicMethod = "Argument_InvalidTypeForDynamicMethod";

    public const string Argument_InvalidTypeName = "Argument_InvalidTypeName";

    public const string Argument_InvalidTypeWithPointersNotSupported = "Argument_InvalidTypeWithPointersNotSupported";

    public const string Argument_InvalidUnity = "Argument_InvalidUnity";

    public const string Argument_LargeInteger = "Argument_LargeInteger";

    public const string Argument_LongEnvVarValue = "Argument_LongEnvVarValue";

    public const string Argument_MethodDeclaringTypeGeneric = "Argument_MethodDeclaringTypeGeneric";

    public const string Argument_MethodDeclaringTypeGenericLcg = "Argument_MethodDeclaringTypeGenericLcg";

    public const string Argument_MethodNeedGenericDeclaringType = "Argument_MethodNeedGenericDeclaringType";

    public const string Argument_MinMaxValue = "Argument_MinMaxValue";

    public const string Argument_MismatchedArrays = "Argument_MismatchedArrays";

    public const string Argument_MustBeFalse = "Argument_MustBeFalse";

    public const string Argument_MustBeRuntimeAssembly = "Argument_MustBeRuntimeAssembly";

    public const string Argument_MustBeRuntimeFieldInfo = "Argument_MustBeRuntimeFieldInfo";

    public const string Argument_MustBeRuntimeMethodInfo = "Argument_MustBeRuntimeMethodInfo";

    public const string Argument_MustBeRuntimeType = "Argument_MustBeRuntimeType";

    public const string Argument_MustBeTypeBuilder = "Argument_MustBeTypeBuilder";

    public const string Argument_MustHaveAttributeBaseClass = "Argument_MustHaveAttributeBaseClass";

    public const string Argument_NativeOverlappedAlreadyFree = "Argument_NativeOverlappedAlreadyFree";

    public const string Argument_NativeOverlappedWrongBoundHandle = "Argument_NativeOverlappedWrongBoundHandle";

    public const string Argument_NeedGenericMethodDefinition = "Argument_NeedGenericMethodDefinition";

    public const string Argument_NeedNonGenericType = "Argument_NeedNonGenericType";

    public const string Argument_NeedStructWithNoRefs = "Argument_NeedStructWithNoRefs";

    public const string Argument_NeverValidGenericArgument = "Argument_NeverValidGenericArgument";

    public const string Argument_NoEra = "Argument_NoEra";

    public const string Argument_NoRegionInvariantCulture = "Argument_NoRegionInvariantCulture";

    public const string Argument_NotAWritableProperty = "Argument_NotAWritableProperty";

    public const string Argument_NotEnoughBytesToRead = "Argument_NotEnoughBytesToRead";

    public const string Argument_NotEnoughBytesToWrite = "Argument_NotEnoughBytesToWrite";

    public const string Argument_NotEnoughGenArguments = "Argument_NotEnoughGenArguments";

    public const string Argument_NotExceptionType = "Argument_NotExceptionType";

    public const string Argument_NotInExceptionBlock = "Argument_NotInExceptionBlock";

    public const string Argument_NotMethodCallOpcode = "Argument_NotMethodCallOpcode";

    public const string Argument_OffsetAndCapacityOutOfBounds = "Argument_OffsetAndCapacityOutOfBounds";

    public const string Argument_OffsetLocalMismatch = "Argument_OffsetLocalMismatch";

    public const string Argument_OffsetOfFieldNotFound = "Argument_OffsetOfFieldNotFound";

    public const string Argument_OffsetOutOfRange = "Argument_OffsetOutOfRange";

    public const string Argument_OffsetPrecision = "Argument_OffsetPrecision";

    public const string Argument_OffsetUtcMismatch = "Argument_OffsetUtcMismatch";

    public const string Argument_OneOfCulturesNotSupported = "Argument_OneOfCulturesNotSupported";

    public const string Argument_OnlyMscorlib = "Argument_OnlyMscorlib";

    public const string Argument_OutOfOrderDateTimes = "Argument_OutOfOrderDateTimes";

    public const string Argument_PathEmpty = "Argument_PathEmpty";

    public const string Argument_PreAllocatedAlreadyAllocated = "Argument_PreAllocatedAlreadyAllocated";

    public const string Argument_RecursiveFallback = "Argument_RecursiveFallback";

    public const string Argument_RecursiveFallbackBytes = "Argument_RecursiveFallbackBytes";

    public const string Argument_RedefinedLabel = "Argument_RedefinedLabel";

    public const string Argument_ResolveField = "Argument_ResolveField";

    public const string Argument_ResolveFieldHandle = "Argument_ResolveFieldHandle";

    public const string Argument_ResolveMember = "Argument_ResolveMember";

    public const string Argument_ResolveMethod = "Argument_ResolveMethod";

    public const string Argument_ResolveMethodHandle = "Argument_ResolveMethodHandle";

    public const string Argument_ResolveModuleType = "Argument_ResolveModuleType";

    public const string Argument_ResolveString = "Argument_ResolveString";

    public const string Argument_ResolveType = "Argument_ResolveType";

    public const string Argument_ResultCalendarRange = "Argument_ResultCalendarRange";

    public const string Argument_SemaphoreInitialMaximum = "Argument_SemaphoreInitialMaximum";

    public const string Argument_ShouldNotSpecifyExceptionType = "Argument_ShouldNotSpecifyExceptionType";

    public const string Argument_ShouldOnlySetVisibilityFlags = "Argument_ShouldOnlySetVisibilityFlags";

    public const string Argument_SigIsFinalized = "Argument_SigIsFinalized";

    public const string Argument_StreamNotReadable = "Argument_StreamNotReadable";

    public const string Argument_StreamNotWritable = "Argument_StreamNotWritable";

    public const string Argument_StringFirstCharIsZero = "Argument_StringFirstCharIsZero";

    public const string Argument_TimeSpanHasSeconds = "Argument_TimeSpanHasSeconds";

    public const string Argument_TimeZoneInfoBadTZif = "Argument_TimeZoneInfoBadTZif";

    public const string Argument_TimeZoneInfoInvalidTZif = "Argument_TimeZoneInfoInvalidTZif";

    public const string Argument_ToExclusiveLessThanFromExclusive = "Argument_ToExclusiveLessThanFromExclusive";

    public const string Argument_TooManyFinallyClause = "Argument_TooManyFinallyClause";

    public const string Argument_TransitionTimesAreIdentical = "Argument_TransitionTimesAreIdentical";

    public const string Argument_TypedReferenceInvalidField = "Argument_TypedReferenceInvalidField";

    public const string Argument_TypeMustNotBeComImport = "Argument_TypeMustNotBeComImport";

    public const string Argument_TypeNameTooLong = "Argument_TypeNameTooLong";

    public const string Argument_UnclosedExceptionBlock = "Argument_UnclosedExceptionBlock";

    public const string Argument_UnknownUnmanagedCallConv = "Argument_UnknownUnmanagedCallConv";

    public const string Argument_UnmanagedMemAccessorWrapAround = "Argument_UnmanagedMemAccessorWrapAround";

    public const string Argument_UnmatchedMethodForLocal = "Argument_UnmatchedMethodForLocal";

    public const string Argument_UnmatchingSymScope = "Argument_UnmatchingSymScope";

    public const string Argument_UTCOutOfRange = "Argument_UTCOutOfRange";

    public const string Argument_WaitHandleNameTooLong = "Argument_WaitHandleNameTooLong";

    public const string ArgumentException_BadMethodImplBody = "ArgumentException_BadMethodImplBody";

    public const string ArgumentException_BufferNotFromPool = "ArgumentException_BufferNotFromPool";

    public const string ArgumentException_OtherNotArrayOfCorrectLength = "ArgumentException_OtherNotArrayOfCorrectLength";

    public const string ArgumentException_NotIsomorphic = "ArgumentException_NotIsomorphic";

    public const string ArgumentException_TupleIncorrectType = "ArgumentException_TupleIncorrectType";

    public const string ArgumentException_TupleLastArgumentNotATuple = "ArgumentException_TupleLastArgumentNotATuple";

    public const string ArgumentException_ValueTupleIncorrectType = "ArgumentException_ValueTupleIncorrectType";

    public const string ArgumentException_ValueTupleLastArgumentNotAValueTuple = "ArgumentException_ValueTupleLastArgumentNotAValueTuple";

    public const string ArgumentNull_Array = "ArgumentNull_Array";

    public const string ArgumentNull_ArrayElement = "ArgumentNull_ArrayElement";

    public const string ArgumentNull_ArrayValue = "ArgumentNull_ArrayValue";

    public const string ArgumentNull_Child = "ArgumentNull_Child";

    public const string ArgumentNull_Generic = "ArgumentNull_Generic";

    public const string ArgumentNull_SafeHandle = "ArgumentNull_SafeHandle";

    public const string ArgumentNull_String = "ArgumentNull_String";

    public const string ArgumentNull_TypedRefType = "ArgumentNull_TypedRefType";

    public const string ArgumentOutOfRange_ActualValue = "ArgumentOutOfRange_ActualValue";

    public const string ArgumentOutOfRange_AddValue = "ArgumentOutOfRange_AddValue";

    public const string ArgumentOutOfRange_BadHourMinuteSecond = "ArgumentOutOfRange_BadHourMinuteSecond";

    public const string ArgumentOutOfRange_BadYearMonthDay = "ArgumentOutOfRange_BadYearMonthDay";

    public const string ArgumentOutOfRange_BiggerThanCollection = "ArgumentOutOfRange_BiggerThanCollection";

    public const string ArgumentOutOfRange_BinaryReaderFillBuffer = "ArgumentOutOfRange_BinaryReaderFillBuffer";

    public const string ArgumentOutOfRange_Bounds_Lower_Upper = "ArgumentOutOfRange_Bounds_Lower_Upper";

    public const string ArgumentOutOfRange_CalendarRange = "ArgumentOutOfRange_CalendarRange";

    public const string ArgumentOutOfRange_Capacity = "ArgumentOutOfRange_Capacity";

    public const string ArgumentOutOfRange_Count = "ArgumentOutOfRange_Count";

    public const string ArgumentOutOfRange_DateArithmetic = "ArgumentOutOfRange_DateArithmetic";

    public const string ArgumentOutOfRange_DateTimeBadMonths = "ArgumentOutOfRange_DateTimeBadMonths";

    public const string ArgumentOutOfRange_DateTimeBadTicks = "ArgumentOutOfRange_DateTimeBadTicks";

    public const string ArgumentOutOfRange_TimeOnlyBadTicks = "ArgumentOutOfRange_TimeOnlyBadTicks";

    public const string ArgumentOutOfRange_DateTimeBadYears = "ArgumentOutOfRange_DateTimeBadYears";

    public const string ArgumentOutOfRange_Day = "ArgumentOutOfRange_Day";

    public const string ArgumentOutOfRange_DayOfWeek = "ArgumentOutOfRange_DayOfWeek";

    public const string ArgumentOutOfRange_DayParam = "ArgumentOutOfRange_DayParam";

    public const string ArgumentOutOfRange_DecimalRound = "ArgumentOutOfRange_DecimalRound";

    public const string ArgumentOutOfRange_EndIndexStartIndex = "ArgumentOutOfRange_EndIndexStartIndex";

    public const string ArgumentOutOfRange_Enum = "ArgumentOutOfRange_Enum";

    public const string ArgumentOutOfRange_Era = "ArgumentOutOfRange_Era";

    public const string ArgumentOutOfRange_FileLengthTooBig = "ArgumentOutOfRange_FileLengthTooBig";

    public const string ArgumentOutOfRange_FileTimeInvalid = "ArgumentOutOfRange_FileTimeInvalid";

    public const string ArgumentOutOfRange_GetByteCountOverflow = "ArgumentOutOfRange_GetByteCountOverflow";

    public const string ArgumentOutOfRange_GetCharCountOverflow = "ArgumentOutOfRange_GetCharCountOverflow";

    public const string ArgumentOutOfRange_HashtableLoadFactor = "ArgumentOutOfRange_HashtableLoadFactor";

    public const string ArgumentOutOfRange_HugeArrayNotSupported = "ArgumentOutOfRange_HugeArrayNotSupported";

    public const string ArgumentOutOfRange_IndexMustBeLess = "ArgumentOutOfRange_IndexMustBeLess";

    public const string ArgumentOutOfRange_IndexMustBeLessOrEqual = "ArgumentOutOfRange_IndexMustBeLessOrEqual";

    public const string ArgumentOutOfRange_IndexCount = "ArgumentOutOfRange_IndexCount";

    public const string ArgumentOutOfRange_IndexCountBuffer = "ArgumentOutOfRange_IndexCountBuffer";

    public const string ArgumentOutOfRange_IndexLength = "ArgumentOutOfRange_IndexLength";

    public const string ArgumentOutOfRange_IndexString = "ArgumentOutOfRange_IndexString";

    public const string ArgumentOutOfRange_InvalidEraValue = "ArgumentOutOfRange_InvalidEraValue";

    public const string ArgumentOutOfRange_InvalidHighSurrogate = "ArgumentOutOfRange_InvalidHighSurrogate";

    public const string ArgumentOutOfRange_InvalidLowSurrogate = "ArgumentOutOfRange_InvalidLowSurrogate";

    public const string ArgumentOutOfRange_InvalidUTF32 = "ArgumentOutOfRange_InvalidUTF32";

    public const string ArgumentOutOfRange_LengthGreaterThanCapacity = "ArgumentOutOfRange_LengthGreaterThanCapacity";

    public const string ArgumentOutOfRange_LessEqualToIntegerMaxVal = "ArgumentOutOfRange_LessEqualToIntegerMaxVal";

    public const string ArgumentOutOfRange_ListInsert = "ArgumentOutOfRange_ListInsert";

    public const string ArgumentOutOfRange_Month = "ArgumentOutOfRange_Month";

    public const string ArgumentOutOfRange_DayNumber = "ArgumentOutOfRange_DayNumber";

    public const string ArgumentOutOfRange_MonthParam = "ArgumentOutOfRange_MonthParam";

    public const string ArgumentOutOfRange_MustBeNonNegNum = "ArgumentOutOfRange_MustBeNonNegNum";

    public const string ArgumentOutOfRange_MustBePositive = "ArgumentOutOfRange_MustBePositive";

    public const string ArgumentOutOfRange_NeedNonNegNum = "ArgumentOutOfRange_NeedNonNegNum";

    public const string ArgumentOutOfRange_NeedNonNegOrNegative1 = "ArgumentOutOfRange_NeedNonNegOrNegative1";

    public const string ArgumentOutOfRange_NeedValidId = "ArgumentOutOfRange_NeedValidId";

    public const string ArgumentOutOfRange_OffsetLength = "ArgumentOutOfRange_OffsetLength";

    public const string ArgumentOutOfRange_OffsetOut = "ArgumentOutOfRange_OffsetOut";

    public const string ArgumentOutOfRange_ParamSequence = "ArgumentOutOfRange_ParamSequence";

    public const string ArgumentOutOfRange_PartialWCHAR = "ArgumentOutOfRange_PartialWCHAR";

    public const string ArgumentOutOfRange_PositionLessThanCapacityRequired = "ArgumentOutOfRange_PositionLessThanCapacityRequired";

    public const string ArgumentOutOfRange_Range = "ArgumentOutOfRange_Range";

    public const string ArgumentOutOfRange_RoundingDigits = "ArgumentOutOfRange_RoundingDigits";

    public const string ArgumentOutOfRange_RoundingDigits_MathF = "ArgumentOutOfRange_RoundingDigits_MathF";

    public const string ArgumentOutOfRange_SmallCapacity = "ArgumentOutOfRange_SmallCapacity";

    public const string ArgumentOutOfRange_StartIndex = "ArgumentOutOfRange_StartIndex";

    public const string ArgumentOutOfRange_StartIndexLargerThanLength = "ArgumentOutOfRange_StartIndexLargerThanLength";

    public const string ArgumentOutOfRange_StreamLength = "ArgumentOutOfRange_StreamLength";

    public const string ArgumentOutOfRange_UIntPtrMax = "ArgumentOutOfRange_UIntPtrMax";

    public const string ArgumentOutOfRange_UnmanagedMemStreamLength = "ArgumentOutOfRange_UnmanagedMemStreamLength";

    public const string ArgumentOutOfRange_UnmanagedMemStreamWrapAround = "ArgumentOutOfRange_UnmanagedMemStreamWrapAround";

    public const string ArgumentOutOfRange_UtcOffset = "ArgumentOutOfRange_UtcOffset";

    public const string ArgumentOutOfRange_UtcOffsetAndDaylightDelta = "ArgumentOutOfRange_UtcOffsetAndDaylightDelta";

    public const string ArgumentOutOfRange_Week = "ArgumentOutOfRange_Week";

    public const string ArgumentOutOfRange_Year = "ArgumentOutOfRange_Year";

    public const string ArgumentOutOfRange_Generic_MustBeNonZero = "ArgumentOutOfRange_Generic_MustBeNonZero";

    public const string ArgumentOutOfRange_Generic_MustBeNonNegative = "ArgumentOutOfRange_Generic_MustBeNonNegative";

    public const string ArgumentOutOfRange_Generic_MustBeNonNegativeNonZero = "ArgumentOutOfRange_Generic_MustBeNonNegativeNonZero";

    public const string ArgumentOutOfRange_Generic_MustBeLessOrEqual = "ArgumentOutOfRange_Generic_MustBeLessOrEqual";

    public const string ArgumentOutOfRange_Generic_MustBeLess = "ArgumentOutOfRange_Generic_MustBeLess";

    public const string ArgumentOutOfRange_Generic_MustBeGreaterOrEqual = "ArgumentOutOfRange_Generic_MustBeGreaterOrEqual";

    public const string ArgumentOutOfRange_Generic_MustBeGreater = "ArgumentOutOfRange_Generic_MustBeGreater";

    public const string ArgumentOutOfRange_Generic_MustBeEqual = "ArgumentOutOfRange_Generic_MustBeEqual";

    public const string ArgumentOutOfRange_Generic_MustBeNotEqual = "ArgumentOutOfRange_Generic_MustBeNotEqual";

    public const string Arithmetic_NaN = "Arithmetic_NaN";

    public const string ArrayTypeMismatch_ConstrainedCopy = "ArrayTypeMismatch_ConstrainedCopy";

    public const string AssemblyLoadContext_Unload_CannotUnloadIfNotCollectible = "AssemblyLoadContext_Unload_CannotUnloadIfNotCollectible";

    public const string AssemblyLoadContext_Verify_NotUnloading = "AssemblyLoadContext_Verify_NotUnloading";

    public const string AssertionFailed = "AssertionFailed";

    public const string AssertionFailed_Cnd = "AssertionFailed_Cnd";

    public const string AssumptionFailed = "AssumptionFailed";

    public const string AssumptionFailed_Cnd = "AssumptionFailed_Cnd";

    public const string AsyncMethodBuilder_InstanceNotInitialized = "AsyncMethodBuilder_InstanceNotInitialized";

    public const string BadImageFormat_BadILFormat = "BadImageFormat_BadILFormat";

    public const string BadImageFormat_InvalidType = "BadImageFormat_InvalidType";

    public const string BadImageFormat_NegativeStringLength = "BadImageFormat_NegativeStringLength";

    public const string BadImageFormat_ParameterSignatureMismatch = "BadImageFormat_ParameterSignatureMismatch";

    public const string BadImageFormat_ResType_SerBlobMismatch = "BadImageFormat_ResType_SerBlobMismatch";

    public const string BadImageFormat_ResourceDataLengthInvalid = "BadImageFormat_ResourceDataLengthInvalid";

    public const string BadImageFormat_ResourceNameCorrupted = "BadImageFormat_ResourceNameCorrupted";

    public const string BadImageFormat_ResourceNameCorrupted_NameIndex = "BadImageFormat_ResourceNameCorrupted_NameIndex";

    public const string BadImageFormat_ResourcesDataInvalidOffset = "BadImageFormat_ResourcesDataInvalidOffset";

    public const string BadImageFormat_ResourcesHeaderCorrupted = "BadImageFormat_ResourcesHeaderCorrupted";

    public const string BadImageFormat_ResourcesIndexTooLong = "BadImageFormat_ResourcesIndexTooLong";

    public const string BadImageFormat_ResourcesNameInvalidOffset = "BadImageFormat_ResourcesNameInvalidOffset";

    public const string BadImageFormat_ResourcesNameTooLong = "BadImageFormat_ResourcesNameTooLong";

    public const string BadImageFormat_TypeMismatch = "BadImageFormat_TypeMismatch";

    public const string CancellationToken_CreateLinkedToken_TokensIsEmpty = "CancellationToken_CreateLinkedToken_TokensIsEmpty";

    public const string CancellationTokenSource_Disposed = "CancellationTokenSource_Disposed";

    public const string ConcurrentCollection_SyncRoot_NotSupported = "ConcurrentCollection_SyncRoot_NotSupported";

    public const string EventSource_AbstractMustNotDeclareEventMethods = "EventSource_AbstractMustNotDeclareEventMethods";

    public const string EventSource_AbstractMustNotDeclareKTOC = "EventSource_AbstractMustNotDeclareKTOC";

    public const string EventSource_AddScalarOutOfRange = "EventSource_AddScalarOutOfRange";

    public const string EventSource_BadHexDigit = "EventSource_BadHexDigit";

    public const string EventSource_ChannelTypeDoesNotMatchEventChannelValue = "EventSource_ChannelTypeDoesNotMatchEventChannelValue";

    public const string EventSource_DataDescriptorsOutOfRange = "EventSource_DataDescriptorsOutOfRange";

    public const string EventSource_DuplicateStringKey = "EventSource_DuplicateStringKey";

    public const string EventSource_EnumKindMismatch = "EventSource_EnumKindMismatch";

    public const string EventSource_EvenHexDigits = "EventSource_EvenHexDigits";

    public const string EventSource_EventChannelOutOfRange = "EventSource_EventChannelOutOfRange";

    public const string EventSource_EventIdReused = "EventSource_EventIdReused";

    public const string EventSource_EventMustHaveTaskIfNonDefaultOpcode = "EventSource_EventMustHaveTaskIfNonDefaultOpcode";

    public const string EventSource_EventMustNotBeExplicitImplementation = "EventSource_EventMustNotBeExplicitImplementation";

    public const string EventSource_EventNameReused = "EventSource_EventNameReused";

    public const string EventSource_EventParametersMismatch = "EventSource_EventParametersMismatch";

    public const string EventSource_EventSourceGuidInUse = "EventSource_EventSourceGuidInUse";

    public const string EventSource_EventTooBig = "EventSource_EventTooBig";

    public const string EventSource_EventWithAdminChannelMustHaveMessage = "EventSource_EventWithAdminChannelMustHaveMessage";

    public const string EventSource_IllegalKeywordsValue = "EventSource_IllegalKeywordsValue";

    public const string EventSource_IllegalOpcodeValue = "EventSource_IllegalOpcodeValue";

    public const string EventSource_IllegalTaskValue = "EventSource_IllegalTaskValue";

    public const string EventSource_IllegalValue = "EventSource_IllegalValue";

    public const string EventSource_IncorrentlyAuthoredTypeInfo = "EventSource_IncorrentlyAuthoredTypeInfo";

    public const string EventSource_InvalidCommand = "EventSource_InvalidCommand";

    public const string EventSource_InvalidEventFormat = "EventSource_InvalidEventFormat";

    public const string EventSource_KeywordCollision = "EventSource_KeywordCollision";

    public const string EventSource_KeywordNeedPowerOfTwo = "EventSource_KeywordNeedPowerOfTwo";

    public const string EventSource_ListenerCreatedInsideCallback = "EventSource_ListenerCreatedInsideCallback";

    public const string EventSource_ListenerNotFound = "EventSource_ListenerNotFound";

    public const string EventSource_ListenerWriteFailure = "EventSource_ListenerWriteFailure";

    public const string EventSource_MaxChannelExceeded = "EventSource_MaxChannelExceeded";

    public const string EventSource_MismatchIdToWriteEvent = "EventSource_MismatchIdToWriteEvent";

    public const string EventSource_NeedGuid = "EventSource_NeedGuid";

    public const string EventSource_NeedName = "EventSource_NeedName";

    public const string EventSource_NeedPositiveId = "EventSource_NeedPositiveId";

    public const string EventSource_NoFreeBuffers = "EventSource_NoFreeBuffers";

    public const string EventSource_NonCompliantTypeError = "EventSource_NonCompliantTypeError";

    public const string EventSource_NoRelatedActivityId = "EventSource_NoRelatedActivityId";

    public const string EventSource_NotSupportedArrayOfBinary = "EventSource_NotSupportedArrayOfBinary";

    public const string EventSource_NotSupportedArrayOfNil = "EventSource_NotSupportedArrayOfNil";

    public const string EventSource_NotSupportedArrayOfNullTerminatedString = "EventSource_NotSupportedArrayOfNullTerminatedString";

    public const string EventSource_NotSupportedNestedArraysEnums = "EventSource_NotSupportedNestedArraysEnums";

    public const string EventSource_NullInput = "EventSource_NullInput";

    public const string EventSource_OpcodeCollision = "EventSource_OpcodeCollision";

    public const string EventSource_PinArrayOutOfRange = "EventSource_PinArrayOutOfRange";

    public const string EventSource_RecursiveTypeDefinition = "EventSource_RecursiveTypeDefinition";

    public const string EventSource_StopsFollowStarts = "EventSource_StopsFollowStarts";

    public const string EventSource_TaskCollision = "EventSource_TaskCollision";

    public const string EventSource_TaskOpcodePairReused = "EventSource_TaskOpcodePairReused";

    public const string EventSource_TooManyArgs = "EventSource_TooManyArgs";

    public const string EventSource_TooManyFields = "EventSource_TooManyFields";

    public const string EventSource_ToString = "EventSource_ToString";

    public const string EventSource_TraitEven = "EventSource_TraitEven";

    public const string EventSource_TypeMustBeSealedOrAbstract = "EventSource_TypeMustBeSealedOrAbstract";

    public const string EventSource_TypeMustDeriveFromEventSource = "EventSource_TypeMustDeriveFromEventSource";

    public const string EventSource_UndefinedChannel = "EventSource_UndefinedChannel";

    public const string EventSource_UndefinedKeyword = "EventSource_UndefinedKeyword";

    public const string EventSource_UndefinedOpcode = "EventSource_UndefinedOpcode";

    public const string EventSource_UnknownEtwTrait = "EventSource_UnknownEtwTrait";

    public const string EventSource_UnsupportedEventTypeInManifest = "EventSource_UnsupportedEventTypeInManifest";

    public const string EventSource_UnsupportedMessageProperty = "EventSource_UnsupportedMessageProperty";

    public const string EventSource_VarArgsParameterMismatch = "EventSource_VarArgsParameterMismatch";

    public const string Exception_EndOfInnerExceptionStack = "Exception_EndOfInnerExceptionStack";

    public const string Exception_EndStackTraceFromPreviousThrow = "Exception_EndStackTraceFromPreviousThrow";

    public const string Exception_WasThrown = "Exception_WasThrown";

    public const string ExecutionContext_ExceptionInAsyncLocalNotification = "ExecutionContext_ExceptionInAsyncLocalNotification";

    public const string FileNotFound_ResolveAssembly = "FileNotFound_ResolveAssembly";

    public const string FileNotFound_LoadFile = "FileNotFound_LoadFile";

    public const string Format_AttributeUsage = "Format_AttributeUsage";

    public const string Format_Bad7BitInt = "Format_Bad7BitInt";

    public const string Format_BadBase64Char = "Format_BadBase64Char";

    public const string Format_BadBoolean = "Format_BadBoolean";

    public const string Format_BadDatePattern = "Format_BadDatePattern";

    public const string Format_BadDateTime = "Format_BadDateTime";

    public const string Format_BadDateOnly = "Format_BadDateOnly";

    public const string Format_BadTimeOnly = "Format_BadTimeOnly";

    public const string Format_DateTimeOnlyContainsNoneDateParts = "Format_DateTimeOnlyContainsNoneDateParts";

    public const string Format_BadDateTimeCalendar = "Format_BadDateTimeCalendar";

    public const string Format_BadDayOfWeek = "Format_BadDayOfWeek";

    public const string Format_BadFormatSpecifier = "Format_BadFormatSpecifier";

    public const string Format_NoFormatSpecifier = "Format_NoFormatSpecifier";

    public const string Format_BadHexChar = "Format_BadHexChar";

    public const string Format_BadHexLength = "Format_BadHexLength";

    public const string Format_BadQuote = "Format_BadQuote";

    public const string Format_BadTimeSpan = "Format_BadTimeSpan";

    public const string Format_DateOutOfRange = "Format_DateOutOfRange";

    public const string Format_EmptyInputString = "Format_EmptyInputString";

    public const string Format_ExtraJunkAtEnd = "Format_ExtraJunkAtEnd";

    public const string Format_GuidBrace = "Format_GuidBrace";

    public const string Format_GuidBraceAfterLastNumber = "Format_GuidBraceAfterLastNumber";

    public const string Format_GuidComma = "Format_GuidComma";

    public const string Format_GuidDashes = "Format_GuidDashes";

    public const string Format_GuidEndBrace = "Format_GuidEndBrace";

    public const string Format_GuidHexPrefix = "Format_GuidHexPrefix";

    public const string Format_GuidInvalidChar = "Format_GuidInvalidChar";

    public const string Format_GuidInvLen = "Format_GuidInvLen";

    public const string Format_GuidUnrecognized = "Format_GuidUnrecognized";

    public const string Format_IndexOutOfRange = "Format_IndexOutOfRange";

    public const string Format_InvalidEnumFormatSpecification = "Format_InvalidEnumFormatSpecification";

    public const string Format_InvalidGuidFormatSpecification = "Format_InvalidGuidFormatSpecification";

    public const string Format_InvalidString = "Format_InvalidString";

    public const string Format_InvalidStringWithValue = "Format_InvalidStringWithValue";

    public const string Format_InvalidStringWithOffsetAndReason = "Format_InvalidStringWithOffsetAndReason";

    public const string Format_UnexpectedClosingBrace = "Format_UnexpectedClosingBrace";

    public const string Format_UnclosedFormatItem = "Format_UnclosedFormatItem";

    public const string Format_ExpectedAsciiDigit = "Format_ExpectedAsciiDigit";

    public const string Format_MissingIncompleteDate = "Format_MissingIncompleteDate";

    public const string Format_NeedSingleChar = "Format_NeedSingleChar";

    public const string Format_NoParsibleDigits = "Format_NoParsibleDigits";

    public const string Format_OffsetOutOfRange = "Format_OffsetOutOfRange";

    public const string Format_RepeatDateTimePattern = "Format_RepeatDateTimePattern";

    public const string Format_StringZeroLength = "Format_StringZeroLength";

    public const string Format_UnknownDateTimeWord = "Format_UnknownDateTimeWord";

    public const string Format_UTCOutOfRange = "Format_UTCOutOfRange";

    public const string Globalization_cp_1200 = "Globalization_cp_1200";

    public const string Globalization_cp_12000 = "Globalization_cp_12000";

    public const string Globalization_cp_12001 = "Globalization_cp_12001";

    public const string Globalization_cp_1201 = "Globalization_cp_1201";

    public const string Globalization_cp_20127 = "Globalization_cp_20127";

    public const string Globalization_cp_28591 = "Globalization_cp_28591";

    public const string Globalization_cp_65000 = "Globalization_cp_65000";

    public const string Globalization_cp_65001 = "Globalization_cp_65001";

    public const string IndexOutOfRange_ArrayRankIndex = "IndexOutOfRange_ArrayRankIndex";

    public const string IndexOutOfRange_UMSPosition = "IndexOutOfRange_UMSPosition";

    public const string InsufficientMemory_MemFailPoint = "InsufficientMemory_MemFailPoint";

    public const string InsufficientMemory_MemFailPoint_TooBig = "InsufficientMemory_MemFailPoint_TooBig";

    public const string InsufficientMemory_MemFailPoint_VAFrag = "InsufficientMemory_MemFailPoint_VAFrag";

    public const string Interop_Marshal_Unmappable_Char = "Interop_Marshal_Unmappable_Char";

    public const string Interop_Marshal_SafeHandle_InvalidOperation = "Interop_Marshal_SafeHandle_InvalidOperation";

    public const string Interop_Marshal_CannotCreateSafeHandleField = "Interop_Marshal_CannotCreateSafeHandleField";

    public const string Interop_Marshal_CannotCreateCriticalHandleField = "Interop_Marshal_CannotCreateCriticalHandleField";

    public const string InvalidCast_CannotCastNullToValueType = "InvalidCast_CannotCastNullToValueType";

    public const string InvalidCast_DBNull = "InvalidCast_DBNull";

    public const string InvalidCast_Empty = "InvalidCast_Empty";

    public const string InvalidCast_FromDBNull = "InvalidCast_FromDBNull";

    public const string InvalidCast_FromTo = "InvalidCast_FromTo";

    public const string InvalidCast_IConvertible = "InvalidCast_IConvertible";

    public const string InvalidOperation_AsyncFlowCtrlCtxMismatch = "InvalidOperation_AsyncFlowCtrlCtxMismatch";

    public const string InvalidOperation_AsyncIOInProgress = "InvalidOperation_AsyncIOInProgress";

    public const string InvalidOperation_BadEmptyMethodBody = "InvalidOperation_BadEmptyMethodBody";

    public const string InvalidOperation_BadILGeneratorUsage = "InvalidOperation_BadILGeneratorUsage";

    public const string InvalidOperation_BadInstructionOrIndexOutOfBound = "InvalidOperation_BadInstructionOrIndexOutOfBound";

    public const string InvalidOperation_BadInterfaceNotAbstract = "InvalidOperation_BadInterfaceNotAbstract";

    public const string InvalidOperation_BadMethodBody = "InvalidOperation_BadMethodBody";

    public const string InvalidOperation_BadTypeAttributesNotAbstract = "InvalidOperation_BadTypeAttributesNotAbstract";

    public const string InvalidOperation_CalledTwice = "InvalidOperation_CalledTwice";

    public const string InvalidOperation_CannotImportGlobalFromDifferentModule = "InvalidOperation_CannotImportGlobalFromDifferentModule";

    public const string InvalidOperation_CannotRegisterSecondResolver = "InvalidOperation_CannotRegisterSecondResolver";

    public const string InvalidOperation_CannotRestoreUnsuppressedFlow = "InvalidOperation_CannotRestoreUnsuppressedFlow";

    public const string InvalidOperation_CannotUseAFCOtherThread = "InvalidOperation_CannotUseAFCOtherThread";

    public const string InvalidOperation_CollectionCorrupted = "InvalidOperation_CollectionCorrupted";

    public const string InvalidOperation_ConcurrentOperationsNotSupported = "InvalidOperation_ConcurrentOperationsNotSupported";

    public const string InvalidOperation_ConstructorNotAllowedOnInterface = "InvalidOperation_ConstructorNotAllowedOnInterface";

    public const string InvalidOperation_DateTimeParsing = "InvalidOperation_DateTimeParsing";

    public const string InvalidOperation_DefaultConstructorILGen = "InvalidOperation_DefaultConstructorILGen";

    public const string InvalidOperation_EnumEnded = "InvalidOperation_EnumEnded";

    public const string InvalidOperation_EnumFailedVersion = "InvalidOperation_EnumFailedVersion";

    public const string InvalidOperation_EnumNotStarted = "InvalidOperation_EnumNotStarted";

    public const string InvalidOperation_EnumOpCantHappen = "InvalidOperation_EnumOpCantHappen";

    public const string InvalidOperation_EventInfoNotAvailable = "InvalidOperation_EventInfoNotAvailable";

    public const string InvalidOperation_GenericParametersAlreadySet = "InvalidOperation_GenericParametersAlreadySet";

    public const string InvalidOperation_GlobalsHaveBeenCreated = "InvalidOperation_GlobalsHaveBeenCreated";

    public const string InvalidOperation_HandleIsNotInitialized = "InvalidOperation_HandleIsNotInitialized";

    public const string InvalidOperation_HandleIsNotPinned = "InvalidOperation_HandleIsNotPinned";

    public const string InvalidOperation_HashInsertFailed = "InvalidOperation_HashInsertFailed";

    public const string InvalidOperation_IComparerFailed = "InvalidOperation_IComparerFailed";

    public const string InvalidOperation_MethodBaked = "InvalidOperation_MethodBaked";

    public const string InvalidOperation_MethodBuilderBaked = "InvalidOperation_MethodBuilderBaked";

    public const string InvalidOperation_MethodHasBody = "InvalidOperation_MethodHasBody";

    public const string InvalidOperation_MustCallInitialize = "InvalidOperation_MustCallInitialize";

    public const string InvalidOperation_NativeOverlappedReused = "InvalidOperation_NativeOverlappedReused";

    public const string InvalidOperation_NestedControlledExecutionRun = "InvalidOperation_NestedControlledExecutionRun";

    public const string InvalidOperation_NoMultiModuleAssembly = "InvalidOperation_NoMultiModuleAssembly";

    public const string InvalidOperation_NoPublicAddMethod = "InvalidOperation_NoPublicAddMethod";

    public const string InvalidOperation_NoPublicRemoveMethod = "InvalidOperation_NoPublicRemoveMethod";

    public const string InvalidOperation_NotADebugModule = "InvalidOperation_NotADebugModule";

    public const string InvalidOperation_NotAllowedInDynamicMethod = "InvalidOperation_NotAllowedInDynamicMethod";

    public const string InvalidOperation_NotAVarArgCallingConvention = "InvalidOperation_NotAVarArgCallingConvention";

    public const string InvalidOperation_NotGenericType = "InvalidOperation_NotGenericType";

    public const string InvalidOperation_NotWithConcurrentGC = "InvalidOperation_NotWithConcurrentGC";

    public const string InvalidOperation_NoUnderlyingTypeOnEnum = "InvalidOperation_NoUnderlyingTypeOnEnum";

    public const string InvalidOperation_NoValue = "InvalidOperation_NoValue";

    public const string InvalidOperation_NullArray = "InvalidOperation_NullArray";

    public const string InvalidOperation_NullContext = "InvalidOperation_NullContext";

    public const string InvalidOperation_NullModuleHandle = "InvalidOperation_NullModuleHandle";

    public const string InvalidOperation_OpenLocalVariableScope = "InvalidOperation_OpenLocalVariableScope";

    public const string InvalidOperation_Overlapped_Pack = "InvalidOperation_Overlapped_Pack";

    public const string InvalidOperation_PropertyInfoNotAvailable = "InvalidOperation_PropertyInfoNotAvailable";

    public const string InvalidOperation_ReadOnly = "InvalidOperation_ReadOnly";

    public const string InvalidOperation_ResMgrBadResSet_Type = "InvalidOperation_ResMgrBadResSet_Type";

    public const string InvalidOperation_ResourceNotStream_Name = "InvalidOperation_ResourceNotStream_Name";

    public const string InvalidOperation_ResourceNotString_Name = "InvalidOperation_ResourceNotString_Name";

    public const string InvalidOperation_ResourceNotString_Type = "InvalidOperation_ResourceNotString_Type";

    public const string InvalidOperation_SetLatencyModeNoGC = "InvalidOperation_SetLatencyModeNoGC";

    public const string InvalidOperation_ShouldNotHaveMethodBody = "InvalidOperation_ShouldNotHaveMethodBody";

    public const string InvalidOperation_ThreadWrongThreadStart = "InvalidOperation_ThreadWrongThreadStart";

    public const string InvalidOperation_TimeoutsNotSupported = "InvalidOperation_TimeoutsNotSupported";

    public const string InvalidOperation_TimerAlreadyClosed = "InvalidOperation_TimerAlreadyClosed";

    public const string InvalidOperation_TypeHasBeenCreated = "InvalidOperation_TypeHasBeenCreated";

    public const string InvalidOperation_TypeNotCreated = "InvalidOperation_TypeNotCreated";

    public const string InvalidOperation_UnderlyingArrayListChanged = "InvalidOperation_UnderlyingArrayListChanged";

    public const string InvalidOperation_UnknownEnumType = "InvalidOperation_UnknownEnumType";

    public const string InvalidOperation_WrongAsyncResultOrEndCalledMultiple = "InvalidOperation_WrongAsyncResultOrEndCalledMultiple";

    public const string InvalidProgram_Default = "InvalidProgram_Default";

    public const string InvalidTimeZone_InvalidId = "InvalidTimeZone_InvalidId";

    public const string InvalidTimeZone_InvalidFileData = "InvalidTimeZone_InvalidFileData";

    public const string InvalidTimeZone_InvalidJulianDay = "InvalidTimeZone_InvalidJulianDay";

    public const string InvalidTimeZone_NoTTInfoStructures = "InvalidTimeZone_NoTTInfoStructures";

    public const string InvalidTimeZone_UnparsablePosixMDateString = "InvalidTimeZone_UnparsablePosixMDateString";

    public const string InvariantFailed = "InvariantFailed";

    public const string InvariantFailed_Cnd = "InvariantFailed_Cnd";

    public const string IO_NoFileTableInInMemoryAssemblies = "IO_NoFileTableInInMemoryAssemblies";

    public const string IO_UnseekableFile = "IO_UnseekableFile";

    public const string IO_EOF_ReadBeyondEOF = "IO_EOF_ReadBeyondEOF";

    public const string IO_FileLoad = "IO_FileLoad";

    public const string IO_FileName_Name = "IO_FileName_Name";

    public const string IO_FileNotFound = "IO_FileNotFound";

    public const string IO_FileNotFound_FileName = "IO_FileNotFound_FileName";

    public const string IO_AlreadyExists_Name = "IO_AlreadyExists_Name";

    public const string IO_DiskFull_Path_AllocationSize = "IO_DiskFull_Path_AllocationSize";

    public const string IO_FileTooLarge_Path_AllocationSize = "IO_FileTooLarge_Path_AllocationSize";

    public const string IO_FileExists_Name = "IO_FileExists_Name";

    public const string IO_FileTooLong2GB = "IO_FileTooLong2GB";

    public const string IO_FileTooLong = "IO_FileTooLong";

    public const string IO_FixedCapacity = "IO_FixedCapacity";

    public const string IO_InvalidStringLen_Len = "IO_InvalidStringLen_Len";

    public const string IO_SeekAppendOverwrite = "IO_SeekAppendOverwrite";

    public const string IO_SeekBeforeBegin = "IO_SeekBeforeBegin";

    public const string IO_SetLengthAppendTruncate = "IO_SetLengthAppendTruncate";

    public const string IO_SharingViolation_File = "IO_SharingViolation_File";

    public const string IO_SharingViolation_NoFileName = "IO_SharingViolation_NoFileName";

    public const string IO_StreamTooLong = "IO_StreamTooLong";

    public const string IO_PathNotFound_NoPathName = "IO_PathNotFound_NoPathName";

    public const string IO_PathNotFound_Path = "IO_PathNotFound_Path";

    public const string IO_PathTooLong = "IO_PathTooLong";

    public const string IO_PathTooLong_Path = "IO_PathTooLong_Path";

    public const string IO_TooManySymbolicLinkLevels = "IO_TooManySymbolicLinkLevels";

    public const string IO_UnknownFileName = "IO_UnknownFileName";

    public const string Lazy_CreateValue_NoParameterlessCtorForT = "Lazy_CreateValue_NoParameterlessCtorForT";

    public const string Lazy_ctor_ModeInvalid = "Lazy_ctor_ModeInvalid";

    public const string Lazy_StaticInit_InvalidOperation = "Lazy_StaticInit_InvalidOperation";

    public const string Lazy_ToString_ValueNotCreated = "Lazy_ToString_ValueNotCreated";

    public const string Lazy_Value_RecursiveCallsToValue = "Lazy_Value_RecursiveCallsToValue";

    public const string ManualResetEventSlim_ctor_TooManyWaiters = "ManualResetEventSlim_ctor_TooManyWaiters";

    public const string Marshaler_StringTooLong = "Marshaler_StringTooLong";

    public const string MissingConstructor_Name = "MissingConstructor_Name";

    public const string MissingField = "MissingField";

    public const string MissingField_Name = "MissingField_Name";

    public const string MissingManifestResource_MultipleBlobs = "MissingManifestResource_MultipleBlobs";

    public const string MissingManifestResource_NoNeutralAsm = "MissingManifestResource_NoNeutralAsm";

    public const string MissingManifestResource_NoNeutralDisk = "MissingManifestResource_NoNeutralDisk";

    public const string MissingMember = "MissingMember";

    public const string MissingMember_Name = "MissingMember_Name";

    public const string MissingMemberNestErr = "MissingMemberNestErr";

    public const string MissingMemberTypeRef = "MissingMemberTypeRef";

    public const string MissingMethod_Name = "MissingMethod_Name";

    public const string MissingSatelliteAssembly_Culture_Name = "MissingSatelliteAssembly_Culture_Name";

    public const string MissingSatelliteAssembly_Default = "MissingSatelliteAssembly_Default";

    public const string Multicast_Combine = "Multicast_Combine";

    public const string MustUseCCRewrite = "MustUseCCRewrite";

    public const string NotSupported_AbstractNonCLS = "NotSupported_AbstractNonCLS";

    public const string NotSupported_ActivAttr = "NotSupported_ActivAttr";

    public const string NotSupported_AssemblyLoadFromHash = "NotSupported_AssemblyLoadFromHash";

    public const string NotSupported_ByRefLike = "NotSupported_ByRefLike";

    public const string NotSupported_ByRefToByRefLikeReturn = "NotSupported_ByRefToByRefLikeReturn";

    public const string NotSupported_ByRefToVoidReturn = "NotSupported_ByRefToVoidReturn";

    public const string NotSupported_CallToVarArg = "NotSupported_CallToVarArg";

    public const string NotSupported_CannotCallEqualsOnSpan = "NotSupported_CannotCallEqualsOnSpan";

    public const string NotSupported_CannotCallGetHashCodeOnSpan = "NotSupported_CannotCallGetHashCodeOnSpan";

    public const string NotSupported_ChangeType = "NotSupported_ChangeType";

    public const string NotSupported_CreateInstanceWithTypeBuilder = "NotSupported_CreateInstanceWithTypeBuilder";

    public const string NotSupported_DynamicAssembly = "NotSupported_DynamicAssembly";

    public const string NotSupported_DynamicMethodFlags = "NotSupported_DynamicMethodFlags";

    public const string NotSupported_DynamicModule = "NotSupported_DynamicModule";

    public const string NotSupported_FixedSizeCollection = "NotSupported_FixedSizeCollection";

    public const string InvalidOperation_SpanOverlappedOperation = "InvalidOperation_SpanOverlappedOperation";

    public const string InvalidOperation_TimeProviderNullLocalTimeZone = "InvalidOperation_TimeProviderNullLocalTimeZone";

    public const string InvalidOperation_TimeProviderInvalidTimestampFrequency = "InvalidOperation_TimeProviderInvalidTimestampFrequency";

    public const string NotSupported_IllegalOneByteBranch = "NotSupported_IllegalOneByteBranch";

    public const string NotSupported_KeyCollectionSet = "NotSupported_KeyCollectionSet";

    public const string NotSupported_MaxWaitHandles = "NotSupported_MaxWaitHandles";

    public const string NotSupported_MemStreamNotExpandable = "NotSupported_MemStreamNotExpandable";

    public const string NotSupported_MustBeModuleBuilder = "NotSupported_MustBeModuleBuilder";

    public const string NotSupported_NoCodepageData = "NotSupported_NoCodepageData";

    public const string InvalidOperation_FunctionMissingUnmanagedCallersOnly = "InvalidOperation_FunctionMissingUnmanagedCallersOnly";

    public const string NotSupported_NonReflectedType = "NotSupported_NonReflectedType";

    public const string NotSupported_NoParentDefaultConstructor = "NotSupported_NoParentDefaultConstructor";

    public const string NotSupported_NoTypeInfo = "NotSupported_NoTypeInfo";

    public const string NotSupported_NYI = "NotSupported_NYI";

    public const string NotSupported_ObsoleteResourcesFile = "NotSupported_ObsoleteResourcesFile";

    public const string NotSupported_OutputStreamUsingTypeBuilder = "NotSupported_OutputStreamUsingTypeBuilder";

    public const string NotSupported_RangeCollection = "NotSupported_RangeCollection";

    public const string NotSupported_Reading = "NotSupported_Reading";

    public const string NotSupported_ReadOnlyCollection = "NotSupported_ReadOnlyCollection";

    public const string NotSupported_ResourceObjectSerialization = "NotSupported_ResourceObjectSerialization";

    public const string NotSupported_StringComparison = "NotSupported_StringComparison";

    public const string NotSupported_SubclassOverride = "NotSupported_SubclassOverride";

    public const string NotSupported_SymbolMethod = "NotSupported_SymbolMethod";

    public const string NotSupported_Type = "NotSupported_Type";

    public const string NotSupported_TypeNotYetCreated = "NotSupported_TypeNotYetCreated";

    public const string NotSupported_UmsSafeBuffer = "NotSupported_UmsSafeBuffer";

    public const string NotSupported_UnitySerHolder = "NotSupported_UnitySerHolder";

    public const string NotSupported_UnreadableStream = "NotSupported_UnreadableStream";

    public const string NotSupported_UnseekableStream = "NotSupported_UnseekableStream";

    public const string NotSupported_UnwritableStream = "NotSupported_UnwritableStream";

    public const string NotSupported_ValueCollectionSet = "NotSupported_ValueCollectionSet";

    public const string NotSupported_Writing = "NotSupported_Writing";

    public const string NotSupported_WrongResourceReader_Type = "NotSupported_WrongResourceReader_Type";

    public const string ObjectDisposed_FileClosed = "ObjectDisposed_FileClosed";

    public const string ObjectDisposed_Generic = "ObjectDisposed_Generic";

    public const string ObjectDisposed_ObjectName_Name = "ObjectDisposed_ObjectName_Name";

    public const string ObjectDisposed_WriterClosed = "ObjectDisposed_WriterClosed";

    public const string ObjectDisposed_ReaderClosed = "ObjectDisposed_ReaderClosed";

    public const string ObjectDisposed_ResourceSet = "ObjectDisposed_ResourceSet";

    public const string ObjectDisposed_StreamClosed = "ObjectDisposed_StreamClosed";

    public const string ObjectDisposed_ViewAccessorClosed = "ObjectDisposed_ViewAccessorClosed";

    public const string OperationCanceled = "OperationCanceled";

    public const string Overflow_Byte = "Overflow_Byte";

    public const string Overflow_Char = "Overflow_Char";

    public const string Overflow_Currency = "Overflow_Currency";

    public const string Overflow_Decimal = "Overflow_Decimal";

    public const string Overflow_Duration = "Overflow_Duration";

    public const string Overflow_Int16 = "Overflow_Int16";

    public const string Overflow_Int32 = "Overflow_Int32";

    public const string Overflow_Int64 = "Overflow_Int64";

    public const string Overflow_Int128 = "Overflow_Int128";

    public const string Overflow_NegateTwosCompNum = "Overflow_NegateTwosCompNum";

    public const string Overflow_NegativeUnsigned = "Overflow_NegativeUnsigned";

    public const string Overflow_SByte = "Overflow_SByte";

    public const string Overflow_TimeSpanElementTooLarge = "Overflow_TimeSpanElementTooLarge";

    public const string Overflow_TimeSpanTooLong = "Overflow_TimeSpanTooLong";

    public const string Overflow_UInt16 = "Overflow_UInt16";

    public const string Overflow_UInt32 = "Overflow_UInt32";

    public const string Overflow_UInt64 = "Overflow_UInt64";

    public const string Overflow_UInt128 = "Overflow_UInt128";

    public const string PlatformNotSupported_ArgIterator = "PlatformNotSupported_ArgIterator";

    public const string PlatformNotSupported_ComInterop = "PlatformNotSupported_ComInterop";

    public const string PlatformNotSupported_NamedSynchronizationPrimitives = "PlatformNotSupported_NamedSynchronizationPrimitives";

    public const string PlatformNotSupported_OSXFileLocking = "PlatformNotSupported_OSXFileLocking";

    public const string PlatformNotSupported_ReflectionOnly = "PlatformNotSupported_ReflectionOnly";

    public const string PlatformNotSupported_Remoting = "PlatformNotSupported_Remoting";

    public const string PlatformNotSupported_SecureBinarySerialization = "PlatformNotSupported_SecureBinarySerialization";

    public const string PlatformNotSupported_StrongNameSigning = "PlatformNotSupported_StrongNameSigning";

    public const string PlatformNotSupported_OverlappedIO = "PlatformNotSupported_OverlappedIO";

    public const string PlatformNotSupported_AppDomains = "PlatformNotSupported_AppDomains";

    public const string PlatformNotSupported_CAS = "PlatformNotSupported_CAS";

    public const string PlatformNotSupported_Principal = "PlatformNotSupported_Principal";

    public const string PlatformNotSupported_ThreadAbort = "PlatformNotSupported_ThreadAbort";

    public const string PlatformNotSupported_ThreadSuspend = "PlatformNotSupported_ThreadSuspend";

    public const string PostconditionFailed = "PostconditionFailed";

    public const string PostconditionFailed_Cnd = "PostconditionFailed_Cnd";

    public const string PostconditionOnExceptionFailed = "PostconditionOnExceptionFailed";

    public const string PostconditionOnExceptionFailed_Cnd = "PostconditionOnExceptionFailed_Cnd";

    public const string PreconditionFailed = "PreconditionFailed";

    public const string PreconditionFailed_Cnd = "PreconditionFailed_Cnd";

    public const string Rank_MultiDimNotSupported = "Rank_MultiDimNotSupported";

    public const string Rank_MustMatch = "Rank_MustMatch";

    public const string ResourceReaderIsClosed = "ResourceReaderIsClosed";

    public const string Resources_StreamNotValid = "Resources_StreamNotValid";

    public const string RFLCT_AmbigCust = "RFLCT_AmbigCust";

    public const string InvalidFilterCriteriaException_CritInt = "InvalidFilterCriteriaException_CritInt";

    public const string InvalidFilterCriteriaException_CritString = "InvalidFilterCriteriaException_CritString";

    public const string RFLCT_InvalidFieldFail = "RFLCT_InvalidFieldFail";

    public const string RFLCT_InvalidPropFail = "RFLCT_InvalidPropFail";

    public const string RFLCT_Targ_ITargMismatch = "RFLCT_Targ_ITargMismatch";

    public const string RFLCT_Targ_StatFldReqTarg = "RFLCT_Targ_StatFldReqTarg";

    public const string RFLCT_Targ_StatMethReqTarg = "RFLCT_Targ_StatMethReqTarg";

    public const string RuntimeWrappedException = "RuntimeWrappedException";

    public const string Security_CannotReadFileData = "Security_CannotReadFileData";

    public const string SemaphoreSlim_ctor_InitialCountWrong = "SemaphoreSlim_ctor_InitialCountWrong";

    public const string SemaphoreSlim_ctor_MaxCountWrong = "SemaphoreSlim_ctor_MaxCountWrong";

    public const string SemaphoreSlim_Release_CountWrong = "SemaphoreSlim_Release_CountWrong";

    public const string SemaphoreSlim_Wait_TimeoutWrong = "SemaphoreSlim_Wait_TimeoutWrong";

    public const string Serialization_BadParameterInfo = "Serialization_BadParameterInfo";

    public const string Serialization_CorruptField = "Serialization_CorruptField";

    public const string Serialization_DateTimeTicksOutOfRange = "Serialization_DateTimeTicksOutOfRange";

    public const string Serialization_DelegatesNotSupported = "Serialization_DelegatesNotSupported";

    public const string Serialization_InsufficientState = "Serialization_InsufficientState";

    public const string Serialization_InvalidData = "Serialization_InvalidData";

    public const string Serialization_InvalidEscapeSequence = "Serialization_InvalidEscapeSequence";

    public const string Serialization_InvalidOnDeser = "Serialization_InvalidOnDeser";

    public const string Serialization_InvalidType = "Serialization_InvalidType";

    public const string Serialization_KeyValueDifferentSizes = "Serialization_KeyValueDifferentSizes";

    public const string Serialization_MissingDateTimeData = "Serialization_MissingDateTimeData";

    public const string Serialization_MissingKeys = "Serialization_MissingKeys";

    public const string Serialization_MissingValues = "Serialization_MissingValues";

    public const string Serialization_NoParameterInfo = "Serialization_NoParameterInfo";

    public const string Serialization_NotFound = "Serialization_NotFound";

    public const string Serialization_NullKey = "Serialization_NullKey";

    public const string Serialization_OptionalFieldVersionValue = "Serialization_OptionalFieldVersionValue";

    public const string Serialization_SameNameTwice = "Serialization_SameNameTwice";

    public const string Serialization_StringBuilderCapacity = "Serialization_StringBuilderCapacity";

    public const string Serialization_StringBuilderMaxCapacity = "Serialization_StringBuilderMaxCapacity";

    public const string SpinLock_Exit_SynchronizationLockException = "SpinLock_Exit_SynchronizationLockException";

    public const string SpinLock_IsHeldByCurrentThread = "SpinLock_IsHeldByCurrentThread";

    public const string SpinLock_TryEnter_ArgumentOutOfRange = "SpinLock_TryEnter_ArgumentOutOfRange";

    public const string SpinLock_TryEnter_LockRecursionException = "SpinLock_TryEnter_LockRecursionException";

    public const string SpinLock_TryReliableEnter_ArgumentException = "SpinLock_TryReliableEnter_ArgumentException";

    public const string SpinWait_SpinUntil_TimeoutWrong = "SpinWait_SpinUntil_TimeoutWrong";

    public const string Task_ContinueWith_ESandLR = "Task_ContinueWith_ESandLR";

    public const string Task_ContinueWith_NotOnAnything = "Task_ContinueWith_NotOnAnything";

    public const string Task_InvalidTimerTimeSpan = "Task_InvalidTimerTimeSpan";

    public const string Task_Delay_InvalidMillisecondsDelay = "Task_Delay_InvalidMillisecondsDelay";

    public const string Task_Dispose_NotCompleted = "Task_Dispose_NotCompleted";

    public const string Task_FromAsync_LongRunning = "Task_FromAsync_LongRunning";

    public const string Task_FromAsync_PreferFairness = "Task_FromAsync_PreferFairness";

    public const string Task_MultiTaskContinuation_EmptyTaskList = "Task_MultiTaskContinuation_EmptyTaskList";

    public const string Task_MultiTaskContinuation_FireOptions = "Task_MultiTaskContinuation_FireOptions";

    public const string Task_MultiTaskContinuation_NullTask = "Task_MultiTaskContinuation_NullTask";

    public const string Task_RunSynchronously_AlreadyStarted = "Task_RunSynchronously_AlreadyStarted";

    public const string Task_RunSynchronously_Continuation = "Task_RunSynchronously_Continuation";

    public const string Task_RunSynchronously_Promise = "Task_RunSynchronously_Promise";

    public const string Task_RunSynchronously_TaskCompleted = "Task_RunSynchronously_TaskCompleted";

    public const string Task_Start_AlreadyStarted = "Task_Start_AlreadyStarted";

    public const string Task_Start_ContinuationTask = "Task_Start_ContinuationTask";

    public const string Task_Start_Promise = "Task_Start_Promise";

    public const string Task_Start_TaskCompleted = "Task_Start_TaskCompleted";

    public const string Task_ThrowIfDisposed = "Task_ThrowIfDisposed";

    public const string Task_WaitMulti_NullTask = "Task_WaitMulti_NullTask";

    public const string TaskCanceledException_ctor_DefaultMessage = "TaskCanceledException_ctor_DefaultMessage";

    public const string TaskCompletionSourceT_TrySetException_NoExceptions = "TaskCompletionSourceT_TrySetException_NoExceptions";

    public const string TaskCompletionSourceT_TrySetException_NullException = "TaskCompletionSourceT_TrySetException_NullException";

    public const string TaskExceptionHolder_UnhandledException = "TaskExceptionHolder_UnhandledException";

    public const string TaskExceptionHolder_UnknownExceptionType = "TaskExceptionHolder_UnknownExceptionType";

    public const string TaskScheduler_ExecuteTask_WrongTaskScheduler = "TaskScheduler_ExecuteTask_WrongTaskScheduler";

    public const string TaskScheduler_FromCurrentSynchronizationContext_NoCurrent = "TaskScheduler_FromCurrentSynchronizationContext_NoCurrent";

    public const string TaskScheduler_InconsistentStateAfterTryExecuteTaskInline = "TaskScheduler_InconsistentStateAfterTryExecuteTaskInline";

    public const string TaskSchedulerException_ctor_DefaultMessage = "TaskSchedulerException_ctor_DefaultMessage";

    public const string TaskT_DebuggerNoResult = "TaskT_DebuggerNoResult";

    public const string TaskT_TransitionToFinal_AlreadyCompleted = "TaskT_TransitionToFinal_AlreadyCompleted";

    public const string Thread_GetSetCompressedStack_NotSupported = "Thread_GetSetCompressedStack_NotSupported";

    public const string Thread_Operation_RequiresCurrentThread = "Thread_Operation_RequiresCurrentThread";

    public const string Threading_AbandonedMutexException = "Threading_AbandonedMutexException";

    public const string Threading_WaitHandleCannotBeOpenedException = "Threading_WaitHandleCannotBeOpenedException";

    public const string Threading_WaitHandleCannotBeOpenedException_InvalidHandle = "Threading_WaitHandleCannotBeOpenedException_InvalidHandle";

    public const string Threading_WaitHandleTooManyPosts = "Threading_WaitHandleTooManyPosts";

    public const string Threading_SemaphoreFullException = "Threading_SemaphoreFullException";

    public const string ThreadLocal_Value_RecursiveCallsToValue = "ThreadLocal_Value_RecursiveCallsToValue";

    public const string ThreadLocal_ValuesNotAvailable = "ThreadLocal_ValuesNotAvailable";

    public const string TimeZoneNotFound_MissingData = "TimeZoneNotFound_MissingData";

    public const string TypeInitialization_Default = "TypeInitialization_Default";

    public const string TypeInitialization_Type = "TypeInitialization_Type";

    public const string TypeLoad_ResolveNestedType = "TypeLoad_ResolveNestedType";

    public const string TypeLoad_ResolveType = "TypeLoad_ResolveType";

    public const string TypeLoad_ResolveTypeFromAssembly = "TypeLoad_ResolveTypeFromAssembly";

    public const string UnauthorizedAccess_IODenied_NoPathName = "UnauthorizedAccess_IODenied_NoPathName";

    public const string UnauthorizedAccess_IODenied_Path = "UnauthorizedAccess_IODenied_Path";

    public const string UnauthorizedAccess_MemStreamBuffer = "UnauthorizedAccess_MemStreamBuffer";

    public const string Verification_Exception = "Verification_Exception";

    public const string DebugAssertBanner = "DebugAssertBanner";

    public const string DebugAssertLongMessage = "DebugAssertLongMessage";

    public const string DebugAssertShortMessage = "DebugAssertShortMessage";

    public const string LockRecursionException_ReadAfterWriteNotAllowed = "LockRecursionException_ReadAfterWriteNotAllowed";

    public const string LockRecursionException_RecursiveReadNotAllowed = "LockRecursionException_RecursiveReadNotAllowed";

    public const string LockRecursionException_RecursiveWriteNotAllowed = "LockRecursionException_RecursiveWriteNotAllowed";

    public const string LockRecursionException_RecursiveUpgradeNotAllowed = "LockRecursionException_RecursiveUpgradeNotAllowed";

    public const string LockRecursionException_WriteAfterReadNotAllowed = "LockRecursionException_WriteAfterReadNotAllowed";

    public const string SynchronizationLockException_MisMatchedUpgrade = "SynchronizationLockException_MisMatchedUpgrade";

    public const string SynchronizationLockException_MisMatchedRead = "SynchronizationLockException_MisMatchedRead";

    public const string SynchronizationLockException_IncorrectDispose = "SynchronizationLockException_IncorrectDispose";

    public const string LockRecursionException_UpgradeAfterReadNotAllowed = "LockRecursionException_UpgradeAfterReadNotAllowed";

    public const string LockRecursionException_UpgradeAfterWriteNotAllowed = "LockRecursionException_UpgradeAfterWriteNotAllowed";

    public const string SynchronizationLockException_MisMatchedWrite = "SynchronizationLockException_MisMatchedWrite";

    public const string NotSupported_SignatureType = "NotSupported_SignatureType";

    public const string HashCode_HashCodeNotSupported = "HashCode_HashCodeNotSupported";

    public const string HashCode_EqualityNotSupported = "HashCode_EqualityNotSupported";

    public const string Arg_TypeNotSupported = "Arg_TypeNotSupported";

    public const string IO_InvalidReadLength = "IO_InvalidReadLength";

    public const string Arg_BasePathNotFullyQualified = "Arg_BasePathNotFullyQualified";

    public const string Argument_AggressiveGCRequiresMaxGeneration = "Argument_AggressiveGCRequiresMaxGeneration";

    public const string Argument_AggressiveGCRequiresBlocking = "Argument_AggressiveGCRequiresBlocking";

    public const string Argument_AggressiveGCRequiresCompacting = "Argument_AggressiveGCRequiresCompacting";

    public const string Argument_OverlapAlignmentMismatch = "Argument_OverlapAlignmentMismatch";

    public const string Arg_MustBeNullTerminatedString = "Arg_MustBeNullTerminatedString";

    public const string ArgumentOutOfRange_Week_ISO = "ArgumentOutOfRange_Week_ISO";

    public const string Argument_BadPInvokeMethod = "Argument_BadPInvokeMethod";

    public const string Argument_BadPInvokeOnInterface = "Argument_BadPInvokeOnInterface";

    public const string Argument_MethodRedefined = "Argument_MethodRedefined";

    public const string Argument_CannotExtractScalar = "Argument_CannotExtractScalar";

    public const string Argument_CannotParsePrecision = "Argument_CannotParsePrecision";

    public const string Argument_GWithPrecisionNotSupported = "Argument_GWithPrecisionNotSupported";

    public const string Argument_PrecisionTooLarge = "Argument_PrecisionTooLarge";

    public const string AssemblyDependencyResolver_FailedToLoadHostpolicy = "AssemblyDependencyResolver_FailedToLoadHostpolicy";

    public const string AssemblyDependencyResolver_FailedToResolveDependencies = "AssemblyDependencyResolver_FailedToResolveDependencies";

    public const string Argument_StructArrayTooLarge = "Argument_StructArrayTooLarge";

    public const string IndexOutOfRange_ArrayWithOffset = "IndexOutOfRange_ArrayWithOffset";

    public const string Serialization_DangerousDeserialization_Switch = "Serialization_DangerousDeserialization_Switch";

    public const string Argument_InvalidStartupHookSimpleAssemblyName = "Argument_InvalidStartupHookSimpleAssemblyName";

    public const string Argument_StartupHookAssemblyLoadFailed = "Argument_StartupHookAssemblyLoadFailed";

    public const string InvalidOperation_ResetGlobalComWrappersInstance = "InvalidOperation_ResetGlobalComWrappersInstance";

    public const string InvalidOperation_ResetGlobalObjectiveCMsgSend = "InvalidOperation_ResetGlobalObjectiveCMsgSend";

    public const string InvalidOperation_ReinitializeObjectiveCMarshal = "InvalidOperation_ReinitializeObjectiveCMarshal";

    public const string InvalidOperation_SuppliedInnerMustBeMarkedAggregation = "InvalidOperation_SuppliedInnerMustBeMarkedAggregation";

    public const string InvalidOperationException_NoGCRegionCallbackAlreadyRegistered = "InvalidOperationException_NoGCRegionCallbackAlreadyRegistered";

    public const string Argument_SpansMustHaveSameLength = "Argument_SpansMustHaveSameLength";

    public const string NotSupported_CannotWriteToBufferedStreamIfReadBufferCannotBeFlushed = "NotSupported_CannotWriteToBufferedStreamIfReadBufferCannotBeFlushed";

    public const string GenericInvalidData = "GenericInvalidData";

    public const string Argument_ResourceScopeWrongDirection = "Argument_ResourceScopeWrongDirection";

    public const string ArgumentNull_TypeRequiredByResourceScope = "ArgumentNull_TypeRequiredByResourceScope";

    public const string Argument_BadResourceScopeTypeBits = "Argument_BadResourceScopeTypeBits";

    public const string Argument_BadResourceScopeVisibilityBits = "Argument_BadResourceScopeVisibilityBits";

    public const string Argument_EmptyString = "Argument_EmptyString";

    public const string Argument_EmptyOrWhiteSpaceString = "Argument_EmptyOrWhiteSpaceString";

    public const string Argument_FrameworkNameInvalid = "Argument_FrameworkNameInvalid";

    public const string Argument_FrameworkNameInvalidVersion = "Argument_FrameworkNameInvalidVersion";

    public const string Argument_FrameworkNameMissingVersion = "Argument_FrameworkNameMissingVersion";

    public const string Argument_FrameworkNameTooShort = "Argument_FrameworkNameTooShort";

    public const string Arg_SwitchExpressionException = "Arg_SwitchExpressionException";

    public const string Arg_ContextMarshalException = "Arg_ContextMarshalException";

    public const string Arg_AppDomainUnloadedException = "Arg_AppDomainUnloadedException";

    public const string SwitchExpressionException_UnmatchedValue = "SwitchExpressionException_UnmatchedValue";

    public const string Encoding_UTF7_Disabled = "Encoding_UTF7_Disabled";

    public const string IDynamicInterfaceCastable_DoesNotImplementRequested = "IDynamicInterfaceCastable_DoesNotImplementRequested";

    public const string IDynamicInterfaceCastable_MissingImplementationAttribute = "IDynamicInterfaceCastable_MissingImplementationAttribute";

    public const string IDynamicInterfaceCastable_NotInterface = "IDynamicInterfaceCastable_NotInterface";

    public const string Arg_MustBeHalf = "Arg_MustBeHalf";

    public const string Arg_MustBeRune = "Arg_MustBeRune";

    public const string BinaryFormatter_SerializationDisallowed = "BinaryFormatter_SerializationDisallowed";

    public const string NotSupported_CodeBase = "NotSupported_CodeBase";

    public const string Activator_CannotCreateInstance = "Activator_CannotCreateInstance";

    public const string ResourceManager_ReflectionNotAllowed = "ResourceManager_ReflectionNotAllowed";

    public const string InvalidOperation_EmptyQueue = "InvalidOperation_EmptyQueue";

    public const string Arg_FileIsDirectory_Name = "Arg_FileIsDirectory_Name";

    public const string Arg_InvalidFileAttrs = "Arg_InvalidFileAttrs";

    public const string Arg_InvalidUnixFileMode = "Arg_InvalidUnixFileMode";

    public const string Arg_Path2IsRooted = "Arg_Path2IsRooted";

    public const string Argument_InvalidSubPath = "Argument_InvalidSubPath";

    public const string IO_CannotReplaceSameFile = "IO_CannotReplaceSameFile";

    public const string IO_NotAFile = "IO_NotAFile";

    public const string IO_SourceDestMustBeDifferent = "IO_SourceDestMustBeDifferent";

    public const string PlatformNotSupported_FileEncryption = "PlatformNotSupported_FileEncryption";

    public const string Arg_MemberInfoNotFound = "Arg_MemberInfoNotFound";

    public const string NullabilityInfoContext_NotSupported = "NullabilityInfoContext_NotSupported";

    public const string NullReference_InvokeNullRefReturned = "NullReference_InvokeNullRefReturned";

    public const string ArgumentOutOfRangeException_NoGCRegionSizeTooLarge = "ArgumentOutOfRangeException_NoGCRegionSizeTooLarge";

    public const string InvalidOperationException_AlreadyInNoGCRegion = "InvalidOperationException_AlreadyInNoGCRegion";

    public const string InvalidOperationException_NoGCRegionAllocationExceeded = "InvalidOperationException_NoGCRegionAllocationExceeded";

    public const string InvalidOperationException_NoGCRegionInduced = "InvalidOperationException_NoGCRegionInduced";

    public const string InvalidOperationException_NoGCRegionNotInProgress = "InvalidOperationException_NoGCRegionNotInProgress";

    public const string InvalidOperationException_HardLimitTooLow = "InvalidOperationException_HardLimitTooLow";

    public const string InvalidOperationException_HardLimitInvalid = "InvalidOperationException_HardLimitInvalid";

    public const string PlatformNotSupported_ReflectionEmit = "PlatformNotSupported_ReflectionEmit";

    public const string Security_InvalidAssemblyPublicKey = "Security_InvalidAssemblyPublicKey";

    public const string ClassLoad_General = "ClassLoad_General";

    public const string ArgumentOutOfRange_NotGreaterThanBufferLength = "ArgumentOutOfRange_NotGreaterThanBufferLength";

    public const string Argument_AssemblyGetTypeCannotSpecifyAssembly = "Argument_AssemblyGetTypeCannotSpecifyAssembly";

    public const string Argument_DirectorySeparatorInvalid = "Argument_DirectorySeparatorInvalid";

    public const string InvalidOperation_NotFunctionPointer = "InvalidOperation_NotFunctionPointer";

    public const string NotSupported_ModifiedType = "NotSupported_ModifiedType";

    public const string Argument_UnexpectedStateForKnownCallback = "Argument_UnexpectedStateForKnownCallback";

    public const string OutOfMemory_StringTooLong = "OutOfMemory_StringTooLong";

    //     static string key
    //     {
    //             if (key.Length == 0)
    //             {
    //                 return key;
    //             }
    // bool lockTaken = false;
    //             try
    //             {
    //                 Monitor.Enter(_lock, ref lockTaken);
    //                 if (_currentlyLoading != null && _currentlyLoading.Count > 0 && _currentlyLoading.LastIndexOf(key) >= 0)
    //                 {
    //                     if (_infinitelyRecursingCount > 0)
    //                     {
    //                         return key;
    //                     }
    //                     _infinitelyRecursingCount++;
    // var message = $"Encountered infinite recursion while looking up resource '{key}' in System.Private.CoreLib. Verify the installation of .NET is complete and does not need repairing, and that the state of the process has not become corrupted.";
    // Environment.FailFast(message);
    //                 }
    //                 if (_currentlyLoading == null)
    // {
    //     _currentlyLoading = new List<string>();
    // }
    // if (!_resourceManagerInited)
    // {
    //     RuntimeHelpers.RunClassConstructor(typeof(ResourceManager)!.TypeHandle);
    //     RuntimeHelpers.RunClassConstructor(typeof(ResourceReader)!.TypeHandle);
    //     RuntimeHelpers.RunClassConstructor(typeof(RuntimeResourceSet)!.TypeHandle);
    //     RuntimeHelpers.RunClassConstructor(typeof(BinaryReader)!.TypeHandle);
    //     _resourceManagerInited = true;
    // }
    // _currentlyLoading.Add(key);
    // string @string = ResourceManager.GetString(key, null);
    // _currentlyLoading.RemoveAt(_currentlyLoading.Count - 1);
    // return @string ?? key;
    //             }
    //             catch
    //             {
    //     if (lockTaken)
    //     {
    //         s_resourceManager = null;
    //         _currentlyLoading = null;
    //     }
    //     throw;
    // }
    //             finally
    //             {
    //     if (lockTaken)
    //     {
    //         Monitor.Exit(_lock);
    //     }
    // }
    //         }

    //         static bool UsingResourceKeys()
    // {
    //     return s_usingResourceKeys;
    // }

    // static string resourceKey
    // {
    //             if (UsingResourceKeys())
    //             {
    //         return resourceKey;
    //     }
    //             string result = null;
    //             try
    //             {
    //         result = InternalresourceKey;
    //         return result;
    //     }
    //             catch (MissingManifestResourceException)
    //             {
    //         return result;
    //     }
    // }
    // static string key
    //     {
    //             if (key.Length == 0)
    //             {
    //                 return key;
    //             }
    // bool lockTaken = false;
    //             try
    //             {
    //                 Monitor.Enter(_lock, ref lockTaken);
    //                 if (_currentlyLoading != null && _currentlyLoading.Count > 0 && _currentlyLoading.LastIndexOf(key) >= 0)
    //                 {
    //                     if (_infinitelyRecursingCount > 0)
    //                     {
    //                         return key;
    //                     }
    //                     _infinitelyRecursingCount++;
    // var message = $"Encountered infinite recursion while looking up resource '{key}' in System.Private.CoreLib. Verify the installation of .NET is complete and does not need repairing, and that the state of the process has not become corrupted.";
    // Environment.FailFast(message);
    //                 }
    //                 if (_currentlyLoading == null)
    // {
    //     _currentlyLoading = new List<string>();
    // }
    // if (!_resourceManagerInited)
    // {
    //     RuntimeHelpers.RunClassConstructor(typeof(ResourceManager)!.TypeHandle);
    //     RuntimeHelpers.RunClassConstructor(typeof(ResourceReader)!.TypeHandle);
    //     RuntimeHelpers.RunClassConstructor(typeof(RuntimeResourceSet)!.TypeHandle);
    //     RuntimeHelpers.RunClassConstructor(typeof(BinaryReader)!.TypeHandle);
    //     _resourceManagerInited = true;
    // }
    // _currentlyLoading.Add(key);
    // string @string = ResourceManager.GetString(key, null);
    // _currentlyLoading.RemoveAt(_currentlyLoading.Count - 1);
    // return @string ?? key;
    //             }
    //             catch
    //             {
    //     if (lockTaken)
    //     {
    //         s_resourceManager = null;
    //         _currentlyLoading = null;
    //     }
    //     throw;
    // }
    //             finally
    //             {
    //     if (lockTaken)
    //     {
    //         Monitor.Exit(_lock);
    //     }
    // }
    //         }

    //         static bool UsingResourceKeys()
    // {
    //     return s_usingResourceKeys;
    // }

    // static string resourceKey
    // {
    //             if (UsingResourceKeys())
    //             {
    //         return resourceKey;
    //     }
    //             string result = null;
    //             try
    //             {
    //         result = InternalresourceKey;
    //         return result;
    //     }
    //             catch (MissingManifestResourceException)
    //             {
    //         return result;
    //     }

    public static string Format(string resourceKey, string defaultString)
    {
        string resourceString = resourceKey;
        if (!(resourceKey == resourceString) && resourceString != null)
        {
            return resourceString;
        }
        return defaultString;
    }

    public static string Format(string resourceFormat, object p1)
    {
        if (UsingResourceKeys())
        {
            return string.Join(", ", resourceFormat, p1);
        }
        return string.Format(resourceFormat, p1);
    }

    public static string Format(string resourceFormat, object p1, object p2)
    {
        if (UsingResourceKeys())
        {
            return string.Join(", ", resourceFormat, p1, p2);
        }
        return string.Format(resourceFormat, p1, p2);
    }

    public static string Format(string resourceFormat, object p1, object p2, object p3)
    {
        if (UsingResourceKeys())
        {
            return string.Join(", ", resourceFormat, p1, p2, p3);
        }
        return string.Format(resourceFormat, p1, p2, p3);
    }

    static string Format(string resourceFormat, params object[] args)
    {
        if (args != null)
        {
            if (UsingResourceKeys())
            {
                return resourceFormat + ", " + string.Join(", ", args);
            }
            return string.Format(resourceFormat, args);
        }
        return resourceFormat;
    }

    static string Format(IFormatProvider provider, string resourceFormat, object p1)
    {
        if (UsingResourceKeys())
        {
            return string.Join(", ", resourceFormat, p1);
        }
        return string.Format(provider, resourceFormat, p1);
    }

    static string Format(IFormatProvider provider, string resourceFormat, object p1, object p2)
    {
        if (UsingResourceKeys())
        {
            return string.Join(", ", resourceFormat, p1, p2);
        }
        return string.Format(provider, resourceFormat, p1, p2);
    }
}
#endif
